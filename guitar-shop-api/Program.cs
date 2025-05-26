using guitar_shop_api.Data;
using guitar_shop_api.Repositories;
using guitar_shop_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<GuitarService>();
builder.Services.AddScoped<GuitarRepository>();
builder.Services.AddScoped<DataContext>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Guitar Shop API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
