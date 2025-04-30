using FlashCardApi.Services;
using Microsoft.OpenApi.Models;
using FlashCardApi.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Flashcard API",
        Version = "v1",
        Description = "An educational flashcard API built with .NET 9 and Angular.",
        Contact = new OpenApiContact
        {
            Name = "Logan Smith",
            Email = "Lsmith2895@gmail.com",
            Url = new Uri("https://github.com/lsmith2895")
        }
    });
});
builder.Services.AddSingleton<IFlashDeckService, FlashDeckService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ProdPolicy", policy =>
    {
        policy.WithOrigins("https://lively-plant-0d0125a1e.6.azurestaticapps.net")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("DevPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<FlashCardDbContext>(options =>
    options.UseSqlite("Data Source=flashcards.db"));

var app = builder.Build();

app.UseCors();
app.MapControllers();

// CORS — switch based on environment
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevPolicy");
}
else
{
    app.UseCors("ProdPolicy");
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flashcard API v1");
    c.RoutePrefix = "swagger";
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FlashCardDbContext>();
    db.Database.EnsureCreated();
    DbSeeder.Seed(db);
}


app.Run();
