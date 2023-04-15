
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.Data.Models;

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
                    .RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy(Constants.Authorize.User, policy => policy
                    .RequireClaim(ClaimTypes.Role,"Admin" ,"User"));
            });
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