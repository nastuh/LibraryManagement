using LibraryManagement.Models.DTOs;
using LibraryManagement.Models.Entities;
using LibraryManagement.Repositories.Interfaces;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            Name = a.Name,
            DateOfBirth = a.DateOfBirth
        });
    }

    public async Task<AuthorDto?> GetByIdAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        return author == null ? null : new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            DateOfBirth = author.DateOfBirth
        };
    }

    public async Task<AuthorDto> CreateAsync(CreateAuthorDto authorDto)
    {
        if (string.IsNullOrWhiteSpace(authorDto.Name))
            throw new ArgumentException("Name is required");

        var author = new Author
        {
            Name = authorDto.Name.Trim(),
            DateOfBirth = authorDto.DateOfBirth
        };

        var createdAuthor = await _authorRepository.AddAsync(author);
        return new AuthorDto
        {
            Id = createdAuthor.Id,
            Name = createdAuthor.Name,
            DateOfBirth = createdAuthor.DateOfBirth
        };
    }

    public async Task<AuthorDto?> UpdateAsync(int id, UpdateAuthorDto authorDto)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author == null) return null;

        author.Name = authorDto.Name.Trim();
        author.DateOfBirth = authorDto.DateOfBirth;

        var updatedAuthor = await _authorRepository.UpdateAsync(author);
        return new AuthorDto
        {
            Id = updatedAuthor.Id,
            Name = updatedAuthor.Name,
            DateOfBirth = updatedAuthor.DateOfBirth
        };
    }

    public async Task<bool> DeleteAsync(int id) => await _authorRepository.DeleteAsync(id);

    public async Task<IEnumerable<AuthorDto>> FindAuthorsByNameAsync(string name)
    {
        var authors = await _authorRepository.FindAuthorsByNameAsync(name);
        return authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            Name = a.Name,
            DateOfBirth = a.DateOfBirth
        });
    }

    public async Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync()
    {
        var authors = await _authorRepository.GetAuthorsWithBooksAsync();
        return authors.Select(a => new AuthorWithBookCountDto
        {
            Id = a.Id,
            Name = a.Name,
            DateOfBirth = a.DateOfBirth,
            BookCount = a.Books.Count
        });
    }
}