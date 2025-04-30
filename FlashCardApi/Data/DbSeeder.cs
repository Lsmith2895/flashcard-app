using FlashCardApi.Models;

namespace FlashCardApi.Data;

public static class DbSeeder
{
    public static void Seed(FlashCardDbContext context)
    {
        if (context.FlashCards.Any()) return; // Already seeded

        var cards = new List<FlashCard>
        {
            new FlashCard("What is C#?", "A modern object-oriented programming language by Microsoft."),
            new FlashCard("What is .NET?", "A cross-platform development framework for building apps."),
            new FlashCard("What keyword declares a class in C#?", "class"),
            new FlashCard("What is Angular?", "A frontend framework for building single-page applications."),
            new FlashCard("What symbol binds input in Angular?", "[]"),
            new FlashCard("What method starts a .NET API?", "dotnet run"),
            new FlashCard("What is a controller in ASP.NET?", "A class that handles HTTP requests and returns responses."),
            new FlashCard("What does EF Core stand for?", "Entity Framework Core"),
            new FlashCard("What is the main purpose of Swagger?", "To generate interactive API documentation."),
            new FlashCard("What command adds a NuGet package?", "dotnet add package <name>")
        };

        context.FlashCards.AddRange(cards);
        context.SaveChanges();
    }
}
