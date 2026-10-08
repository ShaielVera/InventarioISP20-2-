using Backend.Data;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        //string cadenaConexion = configuration.GetConnectionString("mysqlRemote");
        var cadenaConexion = configuration.GetConnectionString("postgresRemote");

        
        builder.Services.AddDbContext<InventarioContext>(
            options => options.UseNpgsql(cadenaConexion));
        
        // Configurar una política de CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder => builder
                    .WithOrigins("http://localhost:5173", "http://sitioweb.com.ar")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowSpecificOrigins");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}