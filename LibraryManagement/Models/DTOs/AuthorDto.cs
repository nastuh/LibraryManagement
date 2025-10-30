namespace LibraryManagement.Models.DTOs;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}

public class CreateAuthorDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}

public class UpdateAuthorDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}