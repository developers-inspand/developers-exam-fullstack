using Domain.Entities.Books;

namespace Application.Usecases.Books.DeleteBook;

public class DeleteBookUseCase
{
    private readonly IBookRepository _bookRepository;
    public DeleteBookUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task ExecuteAsync(long bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        if (book == null)
        {
            throw new Exception("Book not found");
        }

        await _bookRepository.DeleteAsync(bookId);
    }
}
