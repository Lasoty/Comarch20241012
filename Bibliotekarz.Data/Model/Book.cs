namespace Bibliotekarz.Data.Model;

public class Book
{
    public int Id { get; set; }

    public string? Author { get; set; }

    public string Title { get; set; }

    public int PageCount { get; set; }

    public bool IsBorrowed { get; set; }

    public string? Isbn { get; set; }

    public int? BorrowerId { get; set; }
    public Customer? Borrower { get; set; }
}