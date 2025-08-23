namespace Application.Usecases.Books.GetAllBooks;

public record GetAllBooksResponse(long Id, string Title, string Author, string Description) { }