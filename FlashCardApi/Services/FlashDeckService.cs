using FlashCardApi.Models;

namespace FlashCardApi.Services
{
    public class FlashDeckService : IFlashDeckService
    {
        private readonly Queue<FlashCard> _cards = new();
        private FlashCard? _currentCard;

        public FlashDeckService()
        {
            // Initialize deck with some sample cards
            // C# Basics
            _cards.Enqueue(new FlashCard("What keyword is used to define a class in C#?", "class"));
            _cards.Enqueue(new FlashCard("What is the default access modifier for a class in C#?", "internal"));
            _cards.Enqueue(new FlashCard("What does the 'static' keyword mean in C#?", "Belongs to the type itself, not instances."));
            _cards.Enqueue(new FlashCard("What data type is used to store true or false in C#?", "bool"));
            _cards.Enqueue(new FlashCard("What is the method entry point of a C# console application?", "Main"));

            _cards.Enqueue(new FlashCard("What symbol is used to define an interface in C#?", "I (prefix)"));
            _cards.Enqueue(new FlashCard("What is the keyword for inheritance in C#?", ":"));
            _cards.Enqueue(new FlashCard("How do you define a constructor in C#?", "Method with same name as class, no return type."));
            _cards.Enqueue(new FlashCard("What is the purpose of 'using' statements in C#?", "Import namespaces."));
            _cards.Enqueue(new FlashCard("What is the purpose of a namespace in C#?", "Organizes code into logical groups."));

            // C# Advanced
            _cards.Enqueue(new FlashCard("What does 'async' keyword mean in C#?", "Marks a method as asynchronous."));
            _cards.Enqueue(new FlashCard("What type does an async method usually return?", "Task or Task<T>"));
            _cards.Enqueue(new FlashCard("What is LINQ used for in C#?", "Query collections using SQL-like syntax."));
            _cards.Enqueue(new FlashCard("What is the difference between 'ref' and 'out' parameters?", "ref requires initialization before passing; out does not."));
            _cards.Enqueue(new FlashCard("What is polymorphism in C#?", "Ability to take many forms (overriding methods)."));

            _cards.Enqueue(new FlashCard("What is the access modifier that makes members visible to derived classes?", "protected"));
            _cards.Enqueue(new FlashCard("What collection type guarantees unique elements?", "HashSet"));
            _cards.Enqueue(new FlashCard("What is the keyword to implement an interface in C#?", "interface"));
            _cards.Enqueue(new FlashCard("What C# feature allows objects to have flexible property structures at runtime?", "dynamic"));
            _cards.Enqueue(new FlashCard("What operator is used for null-coalescing in C#?", "??"));

            // .NET Basics
            _cards.Enqueue(new FlashCard("What does .NET stand for?", "Network Enabled Technology"));
            _cards.Enqueue(new FlashCard("What is the Common Language Runtime (CLR)?", "Execution engine for .NET programs."));
            _cards.Enqueue(new FlashCard("What is the main package manager for .NET?", "NuGet"));
            _cards.Enqueue(new FlashCard("What is an assembly in .NET?", "Compiled code library (DLL or EXE)."));
            _cards.Enqueue(new FlashCard("What is dependency injection in .NET?", "Providing dependencies to objects at runtime."));

            _cards.Enqueue(new FlashCard("What file defines project dependencies in .NET?", ".csproj"));
            _cards.Enqueue(new FlashCard("What is middleware in ASP.NET Core?", "Software that handles requests and responses."));
            _cards.Enqueue(new FlashCard("What command creates a new .NET project?", "dotnet new"));
            _cards.Enqueue(new FlashCard("What command runs a .NET application?", "dotnet run"));
            _cards.Enqueue(new FlashCard("What is the default template for a .NET Web API project?", "Controllers with attributes and dependency injection."));

            // .NET Advanced
            _cards.Enqueue(new FlashCard("What method maps routes to controllers in ASP.NET Core?", "app.MapControllers()"));
            _cards.Enqueue(new FlashCard("What is CORS used for in .NET APIs?", "Allow cross-origin requests."));
            _cards.Enqueue(new FlashCard("What is Kestrel in .NET?", "Cross-platform web server used by ASP.NET Core."));
            _cards.Enqueue(new FlashCard("What is Entity Framework Core?", "ORM for .NET to work with databases."));
            _cards.Enqueue(new FlashCard("What is a service lifetime in .NET dependency injection?", "The scope of an object's existence (Singleton, Scoped, Transient)."));

            // Angular Basics
            _cards.Enqueue(new FlashCard("What language is Angular primarily written in?", "TypeScript"));
            _cards.Enqueue(new FlashCard("What file contains metadata about an Angular component?", "decorator (@Component)"));
            _cards.Enqueue(new FlashCard("What is Angular's command line interface called?", "Angular CLI"));
            _cards.Enqueue(new FlashCard("What command creates a new Angular component?", "ng generate component <name>"));
            _cards.Enqueue(new FlashCard("What Angular decorator is used for services?", "@Injectable"));

            _cards.Enqueue(new FlashCard("What is two-way data binding syntax in Angular?", "[()]"));
            _cards.Enqueue(new FlashCard("What directive is used for conditional rendering in Angular?", "*ngIf"));
            _cards.Enqueue(new FlashCard("What directive is used for looping in Angular templates?", "*ngFor"));
            _cards.Enqueue(new FlashCard("What lifecycle hook runs after component initialization?", "ngOnInit"));
            _cards.Enqueue(new FlashCard("What Angular module is needed for HTTP requests?", "HttpClientModule"));

            // Angular Advanced
            _cards.Enqueue(new FlashCard("What is a standalone component in Angular?", "A component without needing NgModule declaration."));
            _cards.Enqueue(new FlashCard("What is lazy loading in Angular?", "Loading modules/components only when needed."));
            _cards.Enqueue(new FlashCard("What is the primary design pattern Angular uses?", "Component-based architecture."));
            _cards.Enqueue(new FlashCard("What symbol is used to bind inputs in Angular templates?", "[] (property binding)"));
            _cards.Enqueue(new FlashCard("What symbol is used to bind outputs/events in Angular templates?", "() (event binding)"));
            _cards.Enqueue(new FlashCard("What does RxJS stand for in Angular?", "Reactive Extensions for JavaScript (used for streams and observables)."));
            _cards.Enqueue(new FlashCard("What command builds an Angular app for production?", "ng build --prod"));
            _cards.Enqueue(new FlashCard("What is the default change detection strategy in Angular?", "Check always (default, ChangeDetectionStrategy.Default)."));

            MoveToNextCard(); // Load the first card
        }

        public FlashCard GetCurrentCard()
        {
            if (_currentCard == null)
            {
                throw new InvalidOperationException("No cards available.");
            }

            return _currentCard;
        }

        public void FlipCurrentCard()
        {
            if (_currentCard == null)
            {
                throw new InvalidOperationException("No current card to flip.");
            }

            _currentCard.Flip();
        }

        public void SubmitAnswer(bool isCorrect)
        {
            if (!isCorrect && _currentCard != null)
            {
                // If wrong, re-add the card to the end of the queue
                _currentCard.ResetFlip(); // Reset flip so it's front side when user sees it again
                _cards.Enqueue(_currentCard);
            }
        }

        public void MoveToNextCard()
        {
            if (_cards.Any())
            {
                _currentCard = _cards.Dequeue();
                _currentCard.ResetFlip();
            }
            else
            {
                _currentCard = null;
            }
        }

        public bool IsDeckEmpty()
        {
            return _currentCard == null && !_cards.Any();
        }
    }
}
