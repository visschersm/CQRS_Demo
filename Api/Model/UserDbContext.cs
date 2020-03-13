using Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Model
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext()
        {

        }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogContext;Trusted_Connection=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                //    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            }
        }
    }
}
