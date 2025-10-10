using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatapp.Core.Entities;

namespace Chatapp.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { UserName = "mohamed", Email = "mohamed@test.com" , Password = "mohaamed"},
                    new User { UserName = "ahmed", Email = "ahmed@test.com", Password = "ahmed"}
                );
            }

            context.SaveChanges();
        }
    }

}
