using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // ���������� ��������� � ��
        // Add-Migration <��� ��������> -Context <��� ���������>
        // Update-Database <��� ��������> -Context <��� ���������>
        builder.Services.AddDbContext<CustomUserDbContext>(options =>
            options.UseSqlite("Data Source=SiteDB.db"));
        builder.Services.AddDbContext<ArtworkDbContext>(options =>
            options.UseSqlite("Data Source=SiteDB.db"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nadezha-umiraet-posledney");
                c.DocumentTitle = "API-Info";
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}