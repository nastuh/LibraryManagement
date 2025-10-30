using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

public class AuthorRepository : EfRepository<Author>, IAuthorRepository
{
    private readonly LibraryContext _context;

    public AuthorRepository(LibraryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAuthorsWithBooksAsync() =>
        await _context.Authors.Include(a => a.Books).ToListAsync();

    public async Task<Author?> GetAuthorWithBooksAsync(int id) =>
        await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<Author>> FindAuthorsByNameAsync(string name) =>
        await _context.Authors.Where(a => a.Name.Contains(name)).ToListAsync();

    public async Task<IEnumerable<Author>> GetAuthorsWithBookCountAsync() =>
        await _context.Authors.Include(a => a.Books).ToListAsync();
}