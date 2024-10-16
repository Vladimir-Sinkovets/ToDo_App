using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities.Models;

namespace DataAccess.MsSql
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<ToDoEntry> ToDos {  get; set; }

        public new void SaveChanges() => base.SaveChanges();

        public new async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await base.SaveChangesAsync(cancellationToken);

        public void Migrate() => base.Database.Migrate();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
