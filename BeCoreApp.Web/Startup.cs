using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BeCoreApp.Data.EF;
using BeCoreApp.Data.Entities;
using BeCoreApp.Extensions;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using AutoMapper;
using BeCoreApp.Services;
using BeCoreApp.Helpers;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Data.EF.Repositories;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.Implementation;
using Microsoft.AspNetCore.Authorization;
using BeCoreApp.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using BeCoreApp.Infrastructure.Entensions;
using BeCoreApp.Infrastructure.Tasks.Scheduling;
using BeCoreApp.Application.BackgroundServices;

namespace BeCoreApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("BeCoreApp.Data.EF")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();

            services.AddMinResponse();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(10);
                options.LoginPath = "/login";
                //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddRecaptcha(new RecaptchaOptions()
            {
                SiteKey = Configuration["Recaptcha:SiteKey"],
                SecretKey = Configuration["Recaptcha:SecretKey"]
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(5);
                options.Cookie.HttpOnly = true;
            });
            services.AddImageResizer();
            services.AddAutoMapper();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
               {
                   options.AccessDeniedPath = new PathString("/Account/Access");
                   options.Cookie = new CookieBuilder
                   {
                       //Domain = "",
                       HttpOnly = true,
                       Name = ".aspNetCoreDemo.Security.Cookie",
                       Path = "/",
                       SameSite = SameSiteMode.Lax,
                       SecurePolicy = CookieSecurePolicy.SameAsRequest
                   };
                   options.Events = new CookieAuthenticationEvents
                   {
                       OnSignedIn = context =>
                       {
                           Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                               "OnSignedIn", context.Principal.Identity.Name);
                           return Task.CompletedTask;
                       },
                       OnSigningOut = context =>
                       {
                           Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                               "OnSigningOut", context.HttpContext.User.Identity.Name);
                           return Task.CompletedTask;
                       },
                       OnValidatePrincipal = context =>
                       {
                           Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                               "OnValidatePrincipal", context.Principal.Identity.Name);
                           return Task.CompletedTask;
                       }
                   };

                   options.ExpireTimeSpan = TimeSpan.FromDays(10);
                   options.LoginPath = new PathString("/login");
                   options.ReturnUrlParameter = "RequestPath";
                   options.SlidingExpiration = true;
               })
               .AddFacebook(facebookOpts =>
               {
                   facebookOpts.AppId = Configuration["Authentication:Facebook:AppId"];
                   facebookOpts.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
               })
               .AddGoogle(googleOpts =>
               {
                   googleOpts.ClientId = Configuration["Authentication:Google:ClientId"];
                   googleOpts.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
               });

            // Add application services.
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IViewRenderService, ViewRenderService>();

            services.AddTransient<DbInitializer>();

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services
                .AddMvc(options =>
                {
                    options.CacheProfiles.Add("Default", new CacheProfile() { Duration = 60 });
                    options.CacheProfiles.Add("Never", new CacheProfile() { Location = ResponseCacheLocation.None, NoStore = true });
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(
             opts =>
             {
                 var supportedCultures = new List<CultureInfo>
                 {
                        new CultureInfo("en-US"),
                        new CultureInfo("vi-VN")
                 };

                 opts.DefaultRequestCulture = new RequestCulture("en-US");
                 // Formatting numbers, dates, etc.
                 opts.SupportedCultures = supportedCultures;
                 // UI strings that we have localized.
                 opts.SupportedUICultures = supportedCultures;
             });

            //Scheduler
            //services.AddScheduler((sender, args) =>
            //{
            //    args.SetObserved();
            //});

            //services.AddSingleton<IScheduledTask, SimpleBackgroundTask>();

            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            //Repository
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IMenuGroupRepository, MenuGroupRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBlogTagRepository, BlogTagRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ISupportRepository, SupportRepository>();
            services.AddTransient<INotifyRepository, NotifyRepository>();
            services.AddTransient<IWalletTransferRepository, WalletTransferRepository>();
            services.AddTransient<ITicketTransactionRepository, TicketTransactionRepository>();
            services.AddTransient<IWalletBNBBEP20TransactionRepository, WalletBNBBEP20TransactionRepository>();
            services.AddTransient<IWalletBNBAffiliateTransactionRepository, WalletBNBAffiliateTransactionRepository>();
            services.AddTransient<IWalletInvestTransactionRepository, WalletInvestTransactionRepository>();
            services.AddTransient<IWalletLockTransactionRepository, WalletLockTransactionRepository>();
            services.AddTransient<IChartRoundRepository, ChartRoundRepository>();
            services.AddTransient<ILuckyRoundRepository, LuckyRoundRepository>();
            services.AddTransient<ILuckyRoundHistoryRepository, LuckyRoundHistoryRepository>();

            services.AddTransient<IMetamaskTransactionRepository, MetamaskTransactionRepository>();
            //Service 
            services.AddTransient<ILuckyRoundService, LuckyRoundService>();
            services.AddTransient<ILuckyRoundHistoryService, LuckyRoundHistoryService>();
            services.AddTransient<IChartRoundService, ChartRoundService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IWalletBNBAffiliateTransactionService, WalletBNBAffiliateTransactionService>();
            services.AddTransient<IWalletInvestTransactionService, WalletInvestTransactionService>();
            services.AddTransient<IWalletLockTransactionService, WalletLockTransactionService>();
            services.AddTransient<ITicketTransactionService, TicketTransactionService>();
            services.AddTransient<IWalletBNBBEP20TransactionService, WalletBNBBEP20TransactionService>();
            services.AddTransient<IWalletTransferService, WalletTransferService>();
            services.AddTransient<ITRONService, TRONService>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<INotifyService, NotifyService>();
            services.AddTransient<ISupportService, SupportService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IBlockChainService, BlockChainService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IMenuGroupService, MenuGroupService>();
            services.AddTransient<IMenuItemService, MenuItemService>();
            services.AddTransient<IBlogCategoryService, BlogCategoryService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IFeedbackService, FeedbackService>();

            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IBotTelegramService, BotTelegramService>();
            services.AddTransient<IImportExcelService, ImportExcelService>();
            services.AddTransient<IUploadFileService, UploadFileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddFile("Logs/fbsbatdongsan-{Date}.txt");
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseImageResizer();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMinResponse();
            app.UseAuthentication();
            app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
