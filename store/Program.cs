using System.Reflection.Metadata;
using AutoMapper;
using domain.contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using presistance;
using presistance.data;
using services;
using services.abstractions;
using services.mapping;

namespace store
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
                  //<PrivateAssets>all</PrivateAssets>

            builder.Services.AddControllers();
            builder.Services.AddDbContext<storedbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<idbinitializer, dbinitializer>();
            builder.Services.AddScoped<Iunitofwork, unitofwork>();
            builder.Services.AddScoped<Iservicemanagment, servicemanager>();
            builder.Services.AddAutoMapper(typeof(productprofile).Assembly);
            //builder.Services.AddAutoMapper(typeof(productprofile)); // This line now works with the added using directive



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            await  seeddb(app);

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
       static async Task seeddb(WebApplication app) {
            using var scope = app.Services.CreateScope();
            var dbinitializer = scope.ServiceProvider.GetRequiredService<idbinitializer>();
           await dbinitializer.Initialize();
        }
    }
}
