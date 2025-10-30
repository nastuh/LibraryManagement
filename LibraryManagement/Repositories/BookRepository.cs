using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories;

public class BookRepository : EfRepository<Book>, IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooksWithAuthorsAsync() =>
        await _context.Books.Include(b => b.Author).ToListAsync();

    public async Task<IEnumerable<Book>> GetBooksPublishedAfterYearAsync(int year) =>
        await _context.Books.Include(b => b.Author).Where(b => b.PublishedYear > year).ToListAsync();

    public async Task<IEnumerable<Book>> FindBooksByTitleAsync(string title) =>
        await _context.Books.Include(b => b.Author).Where(b => b.Title.Contains(title)).ToListAsync();

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId) =>
        await _context.Books.Include(b => b.Author).Where(b => b.AuthorId == authorId).ToListAsync();
}