using Bibliotekarz.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() : base()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=Bibliotekarz;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True")
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            ;

        /*
         * Connection string for SQL Server
         * Server - Nazwa serwera i instancji serwera (localhost, inna nazwa)/nazwa instancji (MSSQLSERVER)
         * Database (Initial Catalog) - Nazwa bazy danych
         * Integrated Security - Czy autoryzacja ma być zintegrowana z systemem operacyjnym
         * User ID - Nazwa użytkownika (sa)
         * Password - Hasło użytkownika
         * MultipleActiveResultSets - Zezwala na korzystanie z wielu aktywnych połączeń z bazą danych
         * TrustServerCertificate - Czy certyfikat serwera ma być zaufany
         */


        base.OnConfiguring(optionsBuilder);
    }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Customer> Borrowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().Property(e => e.Author).HasMaxLength(200).IsRequired();
        modelBuilder.Entity<Book>().Property(e => e.Title).HasColumnType("varchar(250)").IsRequired(false);
        modelBuilder.Entity<Book>().Property(e => e.PageCount).IsRequired().HasDefaultValue(1);
        modelBuilder.Entity<Book>().Property(e => e.Isbn).IsRequired(false).HasMaxLength(15);
        
        modelBuilder.Entity<Book>().HasOne(e => e.Borrower).WithMany(c => c.Books).HasForeignKey(e => e.BorrowerId).IsRequired(false);
    }
}