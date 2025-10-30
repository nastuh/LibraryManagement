namespace LibraryManagement.Models.DTOs;

public class AuthorWithBookCountDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public int BookCount { get; set; }
}