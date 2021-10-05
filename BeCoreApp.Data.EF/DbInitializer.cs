using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using BeCoreApp.Data.Entities;

namespace BeCoreApp.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(
            AppDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
        }
    }
}