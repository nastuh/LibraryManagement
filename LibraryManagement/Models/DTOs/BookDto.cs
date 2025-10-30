namespace LibraryManagement.Models.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int AuthorId { get; set; }
    public string? AuthorName { get; set; }
}

public class CreateBookDto
{
    public string Title { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int AuthorId { get; set; }
}

public class UpdateBookDto
{
    public string Title { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int AuthorId { get; set; }
}