using LibraryManagement.Models.Entities;

namespace LibraryManagement.Repositories.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksWithAuthorsAsync();
    Task<IEnumerable<Book>> GetBooksPublishedAfterYearAsync(int year);
    Task<IEnumerable<Book>> FindBooksByTitleAsync(string title);
    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
}