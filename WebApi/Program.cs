
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ISchoolService, SchoolManager>();
            builder.Services.AddScoped<ISchoolDal, EfSchoolDal>();

            builder.Services.AddScoped<IMissionTypeService, MissionTypeManager>();
            builder.Services.AddScoped<IMissionTypeDal, EfMissionTypeDal>();

            builder.Services.AddScoped<IParentDal, EfParentDal>();
            builder.Services.AddScoped<IParentService, ParentManager>();

            builder.Services.AddScoped<IChildDal, EfChildDal>();
            builder.Services.AddScoped<IChildService, ChildManager>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
