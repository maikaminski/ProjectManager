using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // seu front
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Recupera a string de conexão do appsettings.Development.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registra o DbContext com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adiciona suporte a controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

// Usa controllers definidos na aplicação
app.MapControllers();

app.Run();
