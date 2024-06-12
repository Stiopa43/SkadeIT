using Extensions;
using Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServiceInjection();
builder.Services.AddServiceConfiguration(builder.Configuration);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

try
{
    Console.WriteLine("[JS.API] Starting application...");
    if (app.Environment.IsDevelopment())
    {
        using (var provider = builder.Services.BuildServiceProvider())
        using (var scope = provider.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<DbDataSeeder>().Seed();
        }
    }
    Console.WriteLine("[JS.API] Application stopped!");
}
catch (Exception ex)
{
    Console.WriteLine("[JS.API] Application stopped because of exception!");

    throw;
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
