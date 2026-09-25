
using LQthangLesson10._1.Models;
using Microsoft.EntityFrameworkCore;

namespace LQthangLesson10._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var lqtConnection = builder.Configuration.GetConnectionString("LqtK24CNTConnection");

            if (string.IsNullOrWhiteSpace(lqtConnection))
            {
                throw new Exception("Không tìm thấy ConnectionString: LqtK24CNTConnection");
            }

            builder.Services.AddDbContext<Lqtk24cnt2Lesson10Context>(
                x => x.UseSqlServer(lqtConnection));

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

            app.Run();
        }
    }
}
