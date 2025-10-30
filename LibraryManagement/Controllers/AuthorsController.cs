using LibraryManagement.Models.DTOs;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll() =>
        Ok(await _authorService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetById(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        return author == null ? NotFound() : Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> Create(CreateAuthorDto authorDto)
    {
        try
        {
            var author = await _authorService.CreateAsync(authorDto);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AuthorDto>> Update(int id, UpdateAuthorDto authorDto)
    {
        try
        {
            var author = await _authorService.UpdateAsync(id, authorDto);
            return author == null ? NotFound() : Ok(author);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) =>
        await _authorService.DeleteAsync(id) ? NoContent() : NotFound();

    [HttpGet("search/{name}")]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> SearchByName(string name) =>
        Ok(await _authorService.FindAuthorsByNameAsync(name));

    [HttpGet("with-book-count")]
    public async Task<ActionResult<IEnumerable<AuthorWithBookCountDto>>> GetWithBookCount() =>
        Ok(await _authorService.GetAuthorsWithBookCountAsync());
}