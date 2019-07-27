using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.DataAccessLayer
{
    public class DatabaseContext : IdentityDbContext<UserEntity>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=BugCatcher;Integrated Security=True;Connect Timeout=30;Encrypt=False;", opt => opt.MigrationsAssembly("BugCatcher.UI"));
        }
        //public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        //{

        //}

        public DbSet<CategoryEntity> Categories{ get; set; }
        public DbSet<ItemEntity> Items{ get; set; }
        public DbSet<ItemCommentsEntity> ItemComments{ get; set; }
        public DbSet<PriorityEntity> Priorities { get; set; }
        public DbSet<ProjectEntity> Projects{ get; set; }
        public DbSet<SprintEntity> Sprints{ get; set; }
        public DbSet<StageEntity> Stages{ get; set; }
        public DbSet<TeamEntity> Team{ get; set; }
        public DbSet<StatusEntity> Status{ get; set; }
        public DbSet<ProjectSubscribersEntity> ProjectSubscribers{ get; set; }
        public DbSet<ItemSubscribersEntity> ItemSubscribers{ get; set; }
        public DbSet<ItemFileEntity> ItemFiles{ get; set; }
        public DbSet<LogEntity> Log{ get; set; }
        public DbSet<QueryEntity> Queries{ get; set; }
    }
}
