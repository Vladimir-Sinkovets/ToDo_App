using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities.Models;

namespace Infrastructure.Interfaces.DataAccess
{
    public interface IDbContext
    {
        DbSet<ToDoEntry> ToDos { get; }

        void Migrate();
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
