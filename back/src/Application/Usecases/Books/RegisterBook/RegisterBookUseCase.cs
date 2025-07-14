using Domain.Entities.Books;
using FluentValidation.Results;

namespace Application.Usecases.Books.RegisterBook;

public class RegisterBookUseCase
{
    private readonly IBookRepository _bookRepository;

    public RegisterBookUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ValidationResult> ExecuteAsync(RegisterBookRequest request)
    {
        var existingBook = await _bookRepository.ExistsByNameAsync(request.Title);

        if (existingBook)
        {
            return new ValidationResult([new ValidationFailure("Title", "A book with this title already exists.")]);
        }

        var book = Book.Create(request.Title, request.Author, request.Description);

        if (!book.IsValid())
        {
            return book.ValidationResult;
        }

        await _bookRepository.InsertAsync(book);

        return new ValidationResult();
    }
}