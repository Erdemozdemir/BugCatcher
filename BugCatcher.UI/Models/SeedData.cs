using BugCatcher.DataAccessLayer;
using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BugCatcher.UI.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            DatabaseContext context = app.ApplicationServices.GetRequiredService<DatabaseContext>();

            context.Database.Migrate();

            if (!context.Stages.Any())
            {
                context.Stages.AddRange(
                    new StageEntity { Name = "Problem" },
                    new StageEntity { Name = "Analysis" },
                    new StageEntity { Name = "Design" },
                    new StageEntity { Name = "Integration" },
                    new StageEntity { Name = "Bug" },
                    new StageEntity { Name = "Unknown" },
                    new StageEntity { Name = "Customer Request" }
                    );
            }

            if (!context.Priorities.Any())
            {
                context.Priorities.AddRange(
                    new PriorityEntity { Name = "Very Low", Level = 1 },
                    new PriorityEntity { Name = "Low", Level = 2 },
                    new PriorityEntity { Name = "Medium", Level = 3 },
                    new PriorityEntity { Name = "High", Level = 4 },
                    new PriorityEntity { Name = "Very High", Level = 5 },
                    new PriorityEntity { Name = "Emergency", Level = 6 }
                    );
            }

            if (!context.Status.Any())
            {
                context.Status.AddRange(
                    new StatusEntity { Name = "New" },
                    new StatusEntity { Name = "In Progress" },
                    new StatusEntity { Name = "Waiting For Approval" },
                    new StatusEntity { Name = "Pending Customer" },
                    new StatusEntity { Name = "Waiting For Review" }
                    );
            }

            if (!context.Team.Any())
            {
                context.Team.AddRange(
                    new TeamEntity { Name = "Web" },
                    new TeamEntity { Name = "Android" },
                    new TeamEntity { Name = "Sucks" }
                    );
            }

            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new ProjectEntity { Name = "Cms System" },
                    new ProjectEntity { Name = "Hotel Web Site" },
                    new ProjectEntity { Name = "Desktop App" }
                    );
            }

            if (!context.Sprints.Any())
            {
                context.Sprints.AddRange(
                    new SprintEntity { Name = "S1" },
                    new SprintEntity { Name = "S2" },
                    new SprintEntity { Name = "S3" },
                    new SprintEntity { Name = "S4" },
                    new SprintEntity { Name = "S5" },
                    new SprintEntity { Name = "S6" },
                    new SprintEntity { Name = "S7" },
                    new SprintEntity { Name = "Undefined" }
                    );
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new CategoryEntity { Name = "Problem" },
                    new CategoryEntity { Name = "Bug" },
                    new CategoryEntity { Name = "Unknown" },
                    new CategoryEntity { Name = "Customer Request" }
                    );
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new UserEntity
                    {
                        UserName = "Erdem Özdemir",
                        Email = "erdem.ozdemirr@yandex.com",
                        PasswordHash = "123456"
                    },

                    new UserEntity
                    {
                        UserName = "Test User",
                        Email = "test@yandex.com",
                        PasswordHash = "123456"
                    }
                    );
            }

            context.SaveChanges();
        }
    }
}
