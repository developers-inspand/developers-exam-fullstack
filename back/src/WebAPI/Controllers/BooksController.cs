using Application.Usecases.Books.DeleteBook;
using Application.Usecases.Books.GetAllBooks;
using Application.Usecases.Books.GetBook;
using Application.Usecases.Books.RegisterBook;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly RegisterBookUseCase _registerBookUseCase;
    private readonly DeleteBookUseCase _deleteBookUseCase;
    private readonly GetBookById _getBookById;
    private readonly GetAllBooksUseCase _getAllBooksUseCase;

    public BooksController(RegisterBookUseCase registerBookUseCase, DeleteBookUseCase deleteBookUseCase, GetBookById getBookById, GetAllBooksUseCase getAllBooksUseCase)
    {
        _registerBookUseCase = registerBookUseCase;
        _deleteBookUseCase = deleteBookUseCase;
        _getBookById = getBookById;
        _getAllBooksUseCase = getAllBooksUseCase;
    }

    // [HttpGet()]
    // public IEnumerable<object> Get(uint page = 1, uint pageSize = 10)
    // {
    //     List<object> books = [];

    //     for (int i = 0; i < 1000; i++)
    //         books.Add(new { Id = i, Title = $"Book {i}", Author = $"Author {i}", description = $"Book {i} - Description {i}" });

    //     return books.Skip((int)page * (int)pageSize).Take((int)pageSize);
    // }

    [HttpPost()]
    public async Task<IActionResult> Register([FromBody] RegisterBookRequest request)
    {
        var response = await _registerBookUseCase.ExecuteAsync(request);

        return response.IsValid
            ? Created()
            : BadRequest(response.Errors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _deleteBookUseCase.ExecuteAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var book = await _getBookById.ExecuteAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(new { book.Id, book.Title, book.Author, book.Description });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] uint page = 1, uint pageSize = 10)
    {
        var books = await _getAllBooksUseCase.ExecuteAsync(page, pageSize);

        return Ok(books);
    }
}