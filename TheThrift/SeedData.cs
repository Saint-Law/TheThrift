using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThrift.Data;

namespace TheThrift
{
    public class SeedData
    {
        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            //putting userRole and Users into the main section to create the authentication
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            //checking if a user exist and if not create it.
            if (userManager.FindByNameAsync("Admin@localhost.com").Result == null)
            {
                var user = new Employee
                {
                    UserName = "Admin@localhost.com",
                    Email = "Admin@localhost.com"
                };
                var result = userManager.CreateAsync(user, "Password1.").Result;

                //checking if the creation of user is success then add the result
                //and after creating the user add it to role
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
                
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            //checking if users role exist and if not creating the role
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(role).Result; 
            }
        }

        internal static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            throw new NotImplementedException();
        }
    }
}
