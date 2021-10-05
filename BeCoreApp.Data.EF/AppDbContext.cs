using BeCoreApp.Data.EF.Configurations;
using BeCoreApp.Data.EF.Extensions;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BeCoreApp.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Language> Languages { set; get; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<MenuItem> MenuItems { set; get; }
        public DbSet<BlogCategory> BlogCategories { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<BlogTag> BlogTags { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<CustomerTransaction> CustomerTransactions { get; set; }

        public DbSet<WalletBNBBEP20Transaction> WalletBNBBEP20Transactions { get; set; }

        public DbSet<TicketTransaction> TicketTransactions { get; set; }

        public DbSet<WalletBNBAffiliateTransaction> WalletBNBAffiliateTransactions { get; set; }
        public DbSet<WalletInvestTransaction> WalletInvestTransactions { get; set; }
        public DbSet<WalletLockTransaction> WalletLockTransactions { get; set; }

        public DbSet<MetamaskTransaction> MetamaskTransactions { get; set; }

        public DbSet<Support> Supports { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        public DbSet<WalletTransfer> WalletTransfers { get; set; }
        public DbSet<ChartRound> ChartRounds { get; set; }

        public DbSet<LuckyRound> LuckyRounds { get; set; }
        public DbSet<LuckyRoundHistory> LuckyRoundHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims")
                .HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
                .HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins")
                .HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
                .HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            #endregion

            builder.AddConfiguration(new TagConfiguration());
            builder.AddConfiguration(new BlogTagConfiguration());
            builder.AddConfiguration(new FunctionConfiguration());
            builder.AddConfiguration(new BlogConfiguration());
            builder.AddConfiguration(new BlogCategoryConfiguration());

            //base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                        changedOrAddedItem.DateCreated = DateTime.Now;

                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
