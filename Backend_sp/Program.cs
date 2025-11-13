// Import Statement
using Microsoft.OpenApi.Models;
using Backend_sp.Data;
using Backend_sp.Repositories;

// Create Builder
var builder = WebApplication.CreateBuilder(args);

// CORS Configuration (Cross-Origin Resource Sharing)
builder.Services.AddCors(o => o.AddPolicy("AllowNextJs", p =>
    p.WithOrigins("http://localhost:3000", "http://localhost:3000:*").AllowAnyHeader().AllowAnyMethod()));

// Add Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Kel 06", Version = "v1" });
});

// Dependency Injection
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPenggunaRepository, PenggunaRepository>();

// Build App
var app = builder.Build();

// Swagger UI (Hanya Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Kel 06 - V1");
        c.RoutePrefix = string.Empty;
    });
}

// Middleware
app.UseCors("AllowNextJs");      
app.UseAuthorization();            
app.MapControllers();      

// Run App
app.Run();
