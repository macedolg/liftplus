using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using liftplus_apiproject.Data;
using liftplus_apiproject.Repositorios.Interfaces;
using liftplus_apiproject.Repositorios;


namespace liftplus_apiproject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicione serviços ao contêiner.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure o Entity Framework Core para usar o MySQL.
            builder.Services.AddEntityFrameworkMySql()
                .AddDbContext<LiftPLUS_DBContex>(
                    (provider, options) =>
                    {
                        options.UseMySql(provider.GetRequiredService<IConfiguration>().GetConnectionString("DataBase"), new MySqlServerVersion(new Version(8, 0, 34)));

                    }
                );

            builder.Services.AddScoped<iUsuarioRepositorio, UsuarioRepositorio>();

            var app = builder.Build();

            // Configure o pipeline de solicitação HTTP.
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
