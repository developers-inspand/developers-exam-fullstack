using Domain.Entities.Books;

namespace Application.Usecases.Books.GetAllBooks;

public class GetAllBooksUseCase
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<GetAllBooksResponse>> ExecuteAsync(uint page = 1, uint pageSize = 10)
    {
        var response = await _bookRepository.GetAll(page, pageSize);

        List<GetAllBooksResponse> books = [];

        foreach (var book in response.ToList())
        {
            books.Add(new
            (
                book.Id,
                book.Title,
                book.Author,
                book.Description
            ));
        }

        return books;
    }
}
