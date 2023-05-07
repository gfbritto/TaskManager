using Microsoft.AspNetCore.Authentication.Cookies;
using RestEase;
using TaskManager.Services;

namespace TaskManager
{
    public class Program
    {
        private const string TASKS_API_URL = "https://todolist-api.edsonmelo.com.br/api/";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Dependency injection
            builder.Services.AddSingleton<ITaskService>(r => RestClient.For<ITaskService>(TASKS_API_URL));
            builder.Services.AddSingleton<IUserService>(r => RestClient.For<IUserService>(TASKS_API_URL));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login"; // Define a página de login
                    options.LogoutPath = "/User/Logout"; // Define a página de logout
                });

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}