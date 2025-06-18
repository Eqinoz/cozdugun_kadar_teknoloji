
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyRevorlvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddScoped<ISchoolService, SchoolManager>();
            //builder.Services.AddScoped<ISchoolDal, EfSchoolDal>();

            //builder.Services.AddScoped<IMissionTypeService, MissionTypeManager>();
            //builder.Services.AddScoped<IMissionTypeDal, EfMissionTypeDal>();

            //builder.Services.AddScoped<IParentDal, EfParentDal>();
            //builder.Services.AddScoped<IParentService, ParentManager>();

            //builder.Services.AddScoped<IChildDal, EfChildDal>();
            //builder.Services.AddScoped<IChildService, ChildManager>();

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                    };
                });
            builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Autofac Modülünü Aktif Etmek Ýçin
            builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());

                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseCors("AllowAngularDev");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
