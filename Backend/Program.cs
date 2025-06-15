using Backend.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "AllowAngularLocalhost";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod() 
                  .AllowCredentials(); 
                  
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Rick & Morty BFF",
        Version = "v1",
        Description = "Backend .NET 8 para consulta de personajes",
        Contact = new OpenApiContact
        {
            Name = "Javier desarrollador FullStack",
            Url = new Uri("https://github.com/jespinozar89/PruebaTecnicaCarsales/")
        }
    });
});

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));


// Configurar la inyección de dependencias
builder.Services.AddProjectServices();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicy);
app.UseAuthorization();

app.UseRouting();
app.MapControllers(); 

app.Run();
