using DataAccess.Models;
using System.Linq;

namespace DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();

            var mainRole = new Role { RoleId = 0, Type = "Admin" };

            if (!context.Roles.Any())
            {

                context.Roles.Add(mainRole);
                context.Roles.Add(new Role { RoleId = 0, Type = "User" });
            }

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { CategoryId = 0, Name = "Simples", Rate = 100.00 });
                context.Categories.Add(new Category { CategoryId = 0, Name = "Casal", Rate = 120.00 });
                context.Categories.Add(new Category { CategoryId = 0, Name = "Executivo", Rate = 150.00 });
            }

            if (!context.Users.Any())
            {
                var initialUser = new User
                {
                    FirstName = "Administrador",
                    LastName = "Hotel Transilvânia",
                    Email = "admin@google.com",
                    Password = "Ywsrf9viyx8fGrPqbgoP7g==", //admin123
                    Role = mainRole
                };

                context.Users.Add(initialUser);
            }

            context.SaveChanges();
        }
    }
}
