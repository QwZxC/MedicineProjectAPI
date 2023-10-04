using MedicineProject.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MedicineProject.Domain.Services;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Core.Service;
using MedicineProject.Domain.Repositories;
using MedicineProject.Infrastructure.Repositories;
using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.Dashboard;

namespace MedicineProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<WebMobileContext>(
                options => options.UseNpgsql(dbConnectionString));


            builder.Services.AddHangfire(h => h.UsePostgreSqlStorage(dbConnectionString));
            builder.Services.AddHangfireServer();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMemoryCache();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Репозиториии
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
            builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();

            //Сервисы
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IHospitalService, HospitalService>();
            builder.Services.AddScoped<IPlaceService, PlaceService>();

            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseHangfireDashboard();

            app.Run();
        }
    }
}