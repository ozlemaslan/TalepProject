namespace ProjectApp.DataAccess.Migrations
{
    using ProjectApp.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectApp.DataAccess.TalepContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjectApp.DataAccess.TalepContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (!context.Users.Any())
            {
                byte[] passwordHash, passwordSalt;

                CreatePasswordHash("12345", out passwordHash, out passwordSalt);
                User user = new User()
                {
                    Phone = "11111111111",
                    Email = "admin@admin.com.tr",
                    IsAdmin = true,
                    passwordHash = passwordHash,
                    passwordSalt = passwordSalt,
                    

                };
                context.Users.Add(user);
                context.SaveChanges();
            }

        }

        private void CreatePasswordHash(object password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password.ToString()));
            }
        }
    }
}
