using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal static class DatabaseContextInitializer
    {
        static DatabaseContextInitializer()
        {

        }

        internal static void Seed(DatabaseContext databaseContext)
        {
            Guid roleId=Guid.NewGuid();
            
          
            InsertBaseRole(databaseContext, roleId);
            InsertBaseUser(databaseContext, roleId);
            databaseContext.SaveChanges();

        }

        internal static void InsertBaseRole(DatabaseContext databaseContext, Guid roleId)
        {
            Role role = new Role()
            {
                Id = roleId,
                Title = "مدیر وب سایت",
                Name = "Administrator",
                CreationDate = DateTime.Now,
                IsDeleted = false,
                IsActive = true,

            };

            databaseContext.Roles.Add(role);
        }

        internal static void InsertBaseUser(DatabaseContext databaseContext, Guid roleId)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = roleId,
                Username = "admin",
                Password = "kgtoil123!@#",
                FirstName = "baseuser",
                LastName = "baseuser",
                CreationDate = DateTime.Now,
                IsDeleted = false,
                IsActive = true,
            };

            databaseContext.Users.Add(user);
        }
        
    }
}

