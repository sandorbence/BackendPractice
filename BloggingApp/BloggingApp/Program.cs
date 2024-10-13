using Microsoft.EntityFrameworkCore;

using BlogApp.DataAccess.Data;
using BlogApp.DataAccess.Repository;
using BlogApp.DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using BlogApp.DataAccess.DbInitializer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        string username = Environment.GetEnvironmentVariable("POSTGRES_USERNAME", EnvironmentVariableTarget.User);
        string password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD", EnvironmentVariableTarget.User);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
        .Replace("User Id=", $"User Id={username}")
        .Replace("Password=", $"Password={password}")));

        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        using IServiceScope scope = app.Services.CreateScope();
        IDbInitializer dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();

        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

    }
}