using LibraryManagement.Models.DTOs;

namespace LibraryManagement.Services.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAsync();
    Task<AuthorDto?> GetByIdAsync(int id);
    Task<AuthorDto> CreateAsync(CreateAuthorDto authorDto);
    Task<AuthorDto?> UpdateAsync(int id, UpdateAuthorDto authorDto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<AuthorDto>> FindAuthorsByNameAsync(string name);
    Task<IEnumerable<AuthorWithBookCountDto>> GetAuthorsWithBookCountAsync();
}