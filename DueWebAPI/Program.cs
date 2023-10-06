
using DueWebAPI.Data;
using DueWebAPI.Interfaces;
using DueWebAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace DueWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAA, AAService>();
            builder.Services.AddScoped<ICapacite, CapaciteService>();
            builder.Services.AddScoped<ICompetence, CompetenceService>();
            builder.Services.AddScoped<ICursus, CursusService>();
            builder.Services.AddScoped<IDepartement, DepartementService>();
            builder.Services.AddScoped<IUE, UEService>();
            builder.Services.AddScoped<IFiche, FicheService>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}