using Entities;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DbDataSeeder
    {
        private readonly ProjectDbContext dbContext;

        public DbDataSeeder(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            Console.WriteLine("DataSeeder.cs - Seed() STARTING...");
            SeedTechnologies();
            SeedServices();
        }
        public void SeedTechnologies()
        {
            if(!dbContext.Technologies.Any()) 
            {
                List <Technology> technologies = new() 
                { 
                    new Technology(){ Title = "Docker"},
                    new Technology(){ Title = "Asp.Net"},
                    new Technology(){ Title = "Angular"},
                    new Technology(){ Title = "Postres"}
                };
                dbContext.Technologies.AddRange(technologies);
                dbContext.SaveChanges();
            }
        }
        public void SeedServices()
        {
            if (!dbContext.Projects.Any(e=>!e.IsDeleted))
            {
                List<Technology> technologies = dbContext.Technologies.ToList();
                Project service = new Project()
                {
                    Title = "E-shop",
                    Description = "Site did by asp.net",
                    Price = 100,
                    Stage = Common.Enums.Stage.Plan,
                    Technologies = new List<Technology>(),
                    StageDescription = "It will be done in...."
                };
                service.Technologies.AddRange(technologies);
                dbContext.Projects.Add(service);
                dbContext.SaveChanges();
                if(service.Technologies!=null && service.Technologies.Any()) 
                {
                    Console.WriteLine($"SERVICE TECHNILOGIES {service.Technologies.Select(t => t.Title)}");
                }
            }

        }
    }
}
