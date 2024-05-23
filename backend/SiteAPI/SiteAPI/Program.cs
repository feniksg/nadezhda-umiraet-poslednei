using Microsoft.EntityFrameworkCore;
using SiteAPI.Data;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using SiteAPI.Settings;

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
        builder.Services.AddDbContext<ApplicationDbContext>();




        builder.Services.AddOptions<SettingsOptions>(SettingsOptions.Settings);
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
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
            builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());
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
        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}