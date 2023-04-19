
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tagme3a_back_end.BL.Managers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.RepoInterfaces;
using tagme3a_back_end.DAL.Repos;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.BL.Managers.City;
using tagme3a_back_end.BL.Managers.address;
using tagme3a_back_end.BL.Managers.PCManager;
using tagme3a_back_end.BL.Managers.ProductManager;

namespace tagme3a_back_end.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Cors
            var corsPolicy = "AllowAll";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy, p => p.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            #endregion

            #region DB Context
            builder.Services.AddDbContext<MainDbContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("Tagme3aConn"))
            );
            
            #endregion

            #region Identity Managers
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MainDbContext>();
            #endregion

            #region Authentication
            builder.Services.AddAuthentication(options =>
            {
                //Used Authentication Scheme
                options.DefaultAuthenticateScheme = "DefaultAuthentication";

                //Used Challenge Authentication Scheme
                options.DefaultChallengeScheme = "DefaultAuthentication";
            })
                .AddJwtBearer("DefaultAuthentication", options =>
                {
                    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                    var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = secretKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
            #endregion

            #region Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.Authorize.Admin, policy => policy
                    .RequireClaim(ClaimTypes.Role, Constants.Roles.Admin));

                options.AddPolicy(Constants.Authorize.User, policy => policy
                    .RequireClaim(ClaimTypes.Role, Constants.Roles.Admin, Constants.Roles.User));
            });
            #endregion

            #region OrderRepo

            builder.Services.AddScoped<IOrderRepo, orderRepo>();

            #endregion
            
            #region CategoriesRepo & Manager
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            #endregion

            #region BrandsRepo & Manager
            builder.Services.AddScoped<IBrandRepo, BrandRepo>();
            builder.Services.AddScoped<IBrandManager, BrandManager>();
            #endregion

            #region CityRepo

            builder.Services.AddScoped<ICityRepo, CityRepo>();

            #endregion

            #region AddressRepo
            builder.Services.AddScoped<IAddressRepo, AddressRepo>();

            #endregion

            #region PCRepo
            builder.Services.AddScoped<IPCsRepo , PCsRepo>();
            #endregion

            #region OrderManager

            builder.Services.AddScoped<IOrderManager, OrderManager>();
            #endregion

            #region CityManager
            builder.Services.AddScoped<ICityManager, CityManager>();

            #endregion

            #region AddressManager

            builder.Services.AddScoped<IAddressManager, AddressManager>();

            #endregion

            #region PCManager

            builder.Services.AddScoped<IPCManager , PCManager>();

            #endregion

            #region ProductRepo
            builder.Services.AddScoped<IProductRepo , ProductRepo>();
            #endregion

            #region ProductManager

            builder.Services.AddScoped<IProductManager, ProductManager>();

            #endregion

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(corsPolicy);

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
       



            app.MapControllers();

            app.Run();
        }
    }
}