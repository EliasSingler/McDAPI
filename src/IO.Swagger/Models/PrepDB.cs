using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using IO.Swagger.Data;
namespace IO.Swagger.Models
{
    /// <summary>
    /// Class used to prep database
    /// </summary>
    public static class PrepDB
    {
        /// <summary>
        /// Seeds data
        /// </summary>
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<EmployeeContext>());
            }
        }
        /// <summary>
        /// Adds three members to database
        /// </summary>
        public static void SeedData(EmployeeContext context)
        {
            System.Console.WriteLine("Applying Migration....");
            context.Database.Migrate();
            if (!context.Employees.Any())
            {
                System.Console.WriteLine("Seeding....");
                context.Employees.AddRange(
                    new Employee()
                    {
                        Id = 1,
                        Name = "Elias Singler",
                        Title = "Architecture Intern"
                    },
                    new Employee()
                    {
                        Id = 2,
                        Name = "Jeremiah Charles",
                        Title = "Security Intern"
                    },
                    new Employee()
                    {
                        Id = 3,
                        Name = "Zac Hinds",
                        Title = "Software Intern"
                    }
                    ) ; 
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - no need to seed..");
            }
        }
    }
}
