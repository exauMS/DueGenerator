using DueWebApp.Interfaces;
using DueWebApp.Services;

namespace DueWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string uri = builder.Configuration.GetValue<string>("userApi");
            string uriFiche = builder.Configuration.GetValue<string>("ficheApi");
            builder.Services.AddScoped<IUser, UserService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uri) };
                return new UserService(val);
            });
            builder.Services.AddScoped<IDepartement, DepartementService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uriFiche) };
                return new DepartementService(val);
            });
            builder.Services.AddScoped<ICursus, CursusService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uriFiche) };
                return new CursusService(val);
            });
            builder.Services.AddScoped<IUE, UEService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uriFiche) };
                return new UEService(val);
            });
            builder.Services.AddScoped<IAA, AAService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uriFiche) };
                return new AAService(val);
            });

            builder.Services.AddScoped<ICompetence, CompetenceService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uriFiche) };
                return new CompetenceService(val);
            });

            builder.Services.AddScoped<ICapacite, CapaciteService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uriFiche) };
                return new CapaciteService(val);
            });

            builder.Services.AddScoped<IFiche, FicheService>(u => {
                var val = new HttpClient() { BaseAddress = new Uri(uriFiche) };
                return new FicheService(val);
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}