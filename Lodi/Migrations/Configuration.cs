namespace Lodi.Migrations
{
    using Lodi.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lodi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lodi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Regions.AddOrUpdate(x => x.Id,
                new Region() { Id = "eeba5ec8-3df5-4593-b0ca-4113f353de9e", Name = "Asia" },
                new Region() { Id = "6bc0e778-f24c-4a90-af4f-86b303a6f954", Name = "Europe" },
                new Region() { Id = "fd3abbaa-52ca-4165-a6cd-96260596817b", Name = "America" },
                new Region() { Id = "6c4e5527-fa4c-4615-9fdf-8a197ad4a0f9", Name = "Africa" },
                new Region() { Id = "36f25226-575a-4303-87de-5cb0f9047f24", Name = "New Ocean" }
            );
                        
            context.Idols.AddOrUpdate(x => x.Id,
                new Idol() { Id = "9b64891a-2cf7-4706-aa79-717605f46d86", Name = "Justin Biebel", Birthday = DateTime.Parse("20-11-2004"), ImageUrl = "https://randomuser.me/api/portraits/men/82.jpg", Forum = new Forum() { Name = "Idol 1" } },
                new Idol() { Id = "7480074b-7789-4d71-bc8b-7e34c7a93e8c", Name = "My Tam", Birthday = DateTime.Parse("27-06-2001"), ImageUrl = "https://randomuser.me/api/portraits/men/12.jpg" },
                new Idol() { Id = "8ac0d2f3-6fcb-46ae-a5ed-63aa06392438", Name = "Ta Dinh Phong", Birthday = DateTime.Parse("08-01-2002"), ImageUrl = "https://randomuser.me/api/portraits/men/18.jpg" }
            );

            context.SaveChanges();

            //Step 1 Create the user.
            var passwordHasher = new PasswordHasher();

            //var admin_user = new ApplicationUser
            //{
            //    UserName = "lodi_admin@gmail.com",
            //    Email = "lodi_admin@gmail.com",
            //    FirstName = "Lodi",
            //    LastName = "Administrator",
            //    Region = context.Regions.First(),
            //    PasswordHash = passwordHasher.HashPassword("#Admin12345#")
            //};
                
            var pass = "#Admin12345#";
            var email = "lodi_admin@gmail.com";

            var user = context.Users.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var hasher = new PasswordHasher();
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Lodi",
                    LastName = "Administrator",
                    Region = context.Regions.First(),
                    IsAdmin = true
                };

                manager.Create(user, pass);
            }
        }
    }
}
