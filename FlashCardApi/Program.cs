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
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<FlashCardDbContext>(options =>
    options.UseSqlite("Data Source=flashcards.db"));

var app = builder.Build();

app.UseCors();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
