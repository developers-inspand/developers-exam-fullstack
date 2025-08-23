using Domain.Entities.Books.Events;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Entities.Books;

public class Book : Entity<Book>
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Description { get; private set; }

    protected Book() { }

    private Book(string title, string author, string description)
    {
        Title = title;
        Author = author;
        Description = description;
        SetLastAction();
    }

    public static Book Create(string title, string author, string description)
    {
        var book = new Book(title, author, description);
        book.Validate();

        if (!book.ValidationResult.IsValid)
            return book;

        book.RaiseDomainEvent(new BookCreatedEvent(book.Title));
        return book;
    }

    public void Update(string title, string author, string description)
    {
        Title = title;
        Author = author;
        Description = description;
        SetLastAction();
        Validate();
    }

    public override bool IsValid()
    {
        Validate();
        return ValidationResult.IsValid;
    }

    private void Validate()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(10, 100).WithMessage("Title must be between 10 and 100 characters.");

        RuleFor(b => b.Author)
            .NotEmpty().WithMessage("Author is required.")
            .Length(10, 100).WithMessage("Author must be between 10 and 100 characters.");

        RuleFor(b => b.Description)
            .MaximumLength(1024).WithMessage("Description must be at most 1024 characters.");

        ValidationResult = Validate(this);
    }

}
