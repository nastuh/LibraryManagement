using LibraryManagement.Models.Entities;

namespace LibraryManagement.Repositories.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IEnumerable<Author>> GetAuthorsWithBooksAsync();
    Task<Author?> GetAuthorWithBooksAsync(int id);
    Task<IEnumerable<Author>> FindAuthorsByNameAsync(string name);
    Task<IEnumerable<Author>> GetAuthorsWithBookCountAsync();
}