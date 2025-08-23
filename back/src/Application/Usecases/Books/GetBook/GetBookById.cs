using Domain.Entities.Books;

namespace Application.Usecases.Books.GetBook;

public class GetBookById
{

    private readonly IBookRepository _bookRepository;

    public GetBookById(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book?> ExecuteAsync(long id)
    {
        return await _bookRepository.GetById(id);
    }
}
