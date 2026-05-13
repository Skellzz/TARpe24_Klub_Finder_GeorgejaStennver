using Microsoft.EntityFrameworkCore;
using Klub_Finder.Data;
using Klub_Finder.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
namespace Klub_Finder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));
            
            builder.Services.AddSingleton(TimeProvider.System);

            builder.Services.AddSingleton(TimeProvider.System);

            builder.Services.AddIdentityCore<ApplicationUser>(Options =>
            {
                Options.SignIn.RequireConfirmedAccount = false;
                Options.Password.RequiredLength = 2;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireUppercase = false;
                
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddDefaultUI();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(); 


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
