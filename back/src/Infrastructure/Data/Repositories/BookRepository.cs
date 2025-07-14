using Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    private readonly SqlDbContext _context;
    public BookRepository(SqlDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> ExistsByNameAsync(string title)
    {
        return await _context.Books.AnyAsync(b => b.Title == title);
    }

    public async Task<Book?> GetById(long id)
    {
        return await _context.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Book>> GetAll(uint page, uint pageSize)
    {
        return await _context.Books
            .AsNoTracking()
            .Skip((int)(page - 1) * (int)pageSize)
            .Take((int)pageSize)
            .ToListAsync();
    }
}
