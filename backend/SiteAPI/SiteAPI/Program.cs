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

        // Добавление контекста к бд
        // Add-Migration <Имя миграции> 
        // Update-Database <Имя миграции> 
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data Source=SiteDB.db"));

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Nadezha-umiraet-posledney",
                Description = "This is our coursework in the C# discipline. This is a model of the website of the museum of V.V. Vereshchagin\r\nHere is a toolkit for working with objects in our application",
                Contact = new OpenApiContact
                {
                    Name = "1PIb-01-2op-21",
                    Email = "nadezhdanotdeath@gmail.com",
                    Url = new Uri("https://nadezhdanotdeath.com")
                }
            });
        });


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