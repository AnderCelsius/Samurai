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
        public static async Task SeedData(AppDbContext dbContext)
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


            await dbContext.SaveChangesAsync();
        }

        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}
