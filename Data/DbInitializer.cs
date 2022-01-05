using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Threading.Tasks;
using FinalProject;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async void Initialize()
        {
            try
            {
                if ( _dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }
            }
            catch (Exception e)
            {
            }

            if (_dbContext.Roles.Any(r => r.Name == "Admin")) return;

            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser()
            {
                UserName = "danielledulong@gmail.com",
                Email = "danielledulong@gmail.com",
                FirstName = "Danielle",
                LastName = "DuLong",
                StreetAddress = "123 Main Street",
                PhoneNumber = "0000000000",
                City = "Bay City",
                State = "Michigan",
                PostalCode = "48706",
                EmailConfirmed = true

            }, "Password123!").GetAwaiter().GetResult();

            IdentityUser user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == "danielledulong@gmail.com");

            await _userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
