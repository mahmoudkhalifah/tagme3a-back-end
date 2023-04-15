
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using tagme3a_back_end.BL.Managers;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.RepoInterfaces;
using tagme3a_back_end.DAL.Repos;

namespace tagme3a_back_end.API
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

            builder.Services.AddDbContext<MainDbContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("Tagme3aConn"))
            );

            #region Repos

            builder.Services.AddScoped<IOrderRepo, orderRepo>();
 
            #endregion

            #region Managers

            builder.Services.AddScoped<IOrderManager, OrderManager>();
            #endregion

           

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