using LibraryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seed data
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "Лев Толстой", DateOfBirth = new DateTime(1828, 9, 9) },
            new Author { Id = 2, Name = "Федор Достоевский", DateOfBirth = new DateTime(1821, 11, 11) },
            new Author { Id = 3, Name = "Антон Чехов", DateOfBirth = new DateTime(1860, 1, 29) }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Война и мир", PublishedYear = 1869, AuthorId = 1 },
            new Book { Id = 2, Title = "Анна Каренина", PublishedYear = 1877, AuthorId = 1 },
            new Book { Id = 3, Title = "Преступление и наказание", PublishedYear = 1866, AuthorId = 2 },
            new Book { Id = 4, Title = "Братья Карамазовы", PublishedYear = 1880, AuthorId = 2 },
            new Book { Id = 5, Title = "Вишневый сад", PublishedYear = 1904, AuthorId = 3 },
            new Book { Id = 6, Title = "Чайка", PublishedYear = 1896, AuthorId = 3 }
        );
    }
}