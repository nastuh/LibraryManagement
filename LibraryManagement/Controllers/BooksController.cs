using LibraryManagement.Models.DTOs;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll() =>
        Ok(await _bookService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById(int id)
    {
        var book = await _bookService.GetByIdAsync(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> Create(CreateBookDto bookDto)
    {
        try
        {
            var book = await _bookService.CreateAsync(bookDto);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookDto>> Update(int id, UpdateBookDto bookDto)
    {
        try
        {
            var book = await _bookService.UpdateAsync(id, bookDto);
            return book == null ? NotFound() : Ok(book);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) =>
        await _bookService.DeleteAsync(id) ? NoContent() : NotFound();

    [HttpGet("published-after/{year}")]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetPublishedAfter(int year) =>
        Ok(await _bookService.GetBooksPublishedAfterYearAsync(year));

    [HttpGet("search/{title}")]
    public async Task<ActionResult<IEnumerable<BookDto>>> SearchByTitle(string title) =>
        Ok(await _bookService.FindBooksByTitleAsync(title));

    [HttpGet("author/{authorId}")]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetByAuthor(int authorId) =>
        Ok(await _bookService.GetBooksByAuthorIdAsync(authorId));
}