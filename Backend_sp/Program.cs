using Microsoft.OpenApi.Models;
using Backend_sp.Data;
using Backend_sp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("AllowNextJs", p =>
    p.WithOrigins("http://localhost:3000", "http://localhost:3000:*").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My First API", Version = "v1" });
});

// Registrasi DI
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IPenggunaRepository, PenggunaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowNextJs");
// app.UseHttpsRedirection();  // COMMENT INI DULU UNTUK DEVELOPMENT
app.UseAuthorization();
app.MapControllers();

app.Run();
