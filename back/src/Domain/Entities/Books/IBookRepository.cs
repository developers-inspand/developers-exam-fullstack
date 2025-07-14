using Domain.Interfaces;

namespace Domain.Entities.Books;

public interface IBookRepository : IRepository<Book>
{
    Task<bool> ExistsByNameAsync(string title);
    Task<Book?> GetById(long id);
    Task<IEnumerable<Book>> GetAll(uint page, uint pageSize);
}