using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskillz.Models;

namespace Upskillz.Data.Seeder
{
    public class Seeder
    {
        public static async Task SeedData(AppDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var baseDir = Directory.GetCurrentDirectory();

            await dbContext.Database.EnsureCreatedAsync();           


            // Samurais and Quotes
            if (!dbContext.Samurais.Any())
            {
                var path = File.ReadAllText(FilePath(baseDir, "wwwroot/data/Samurais.json"));

                var samurais = JsonConvert.DeserializeObject<List<Samurai>>(path);
                await dbContext.Samurais.AddRangeAsync(samurais);
            }

            if (!dbContext.Users.Any())
            {
                List<string> roles = new List<string> { "Admin", "Regular" };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }

                var user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Obinna",
                    LastName = "Asiegbulam",
                    Email = "oasiegbulam@gmail.com",
                    PhoneNumber = "08036021425",
                    Gender = "Male",
                    PublicId = null,
                    Avatar = "https://www.pngfind.com/pngs/m/676-6764065_default-profile-picture-transparent-hd-png-download.png",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                user.UserName = user.Email;
                user.EmailConfirmed = true;
                await userManager.CreateAsync(user, "Password@123");
                await userManager.AddToRoleAsync(user, "Admin");

            }


            await dbContext.SaveChangesAsync();
        }

        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}
