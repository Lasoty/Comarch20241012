using Bibliotekarz.Data.Context;
using Bibliotekarz.Data.Model;
using Bibliotekarz.Services.DTOs;
using Mapster;

namespace Bibliotekarz.Services;

public class BookService
{
    public ICollection<BookDto> GetAllBooks()
    {
        using AppDbContext dbContext = new();
        List<Book> books = dbContext.Books.ToList();

        return books.Select(b => new BookDto
        {
            Id = b.Id,
            Author = b.Author,
            Title = b.Title,
            PageCount = b.PageCount,
            IsBorrowed = b.BorrowerId.HasValue,
            Borrower = b.BorrowerId.HasValue ? new CustomerDto
            {
                Id = b.Borrower.Id,
                FirstName = b.Borrower.FirstName,
                LastName = b.Borrower.LastName
            } : null
        }).ToList();


    }

    public bool AddBook(BookDto book)
    {
        
        Book bookEntity = book.Adapt<Book>();
        using AppDbContext dbContext = new();
        dbContext.Books.Add(bookEntity);
        dbContext.SaveChanges();

        return true;
    }
}