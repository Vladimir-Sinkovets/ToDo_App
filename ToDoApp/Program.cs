using DataAccess.MsSql;
using Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using UseCases.DI;

namespace ToDoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<IDbContext, ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            builder.Services.AddUseCases();


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IDbContext>();

                dbContext.Migrate();
            }

            app.Run();
        }
    }
}
