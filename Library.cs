using Bookish.Enums;
using Bookish.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookish;

public class Library : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Copy> Copies { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=bookish; Username=bookish; Password=bookish;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var book1 = new Book
        {
            Id = 1,
            Title = "My special book",
            Author = "Emily",
        };
        var book2 = new Book
        {
            Id = 2,
            Title = "I am a legend",
            Author = "Paola",
        };

        modelBuilder.Entity<Book>().HasMany(book => book.Copies).WithOne(copy => copy.Book);
        modelBuilder.Entity<Book>().HasData(book1);
        modelBuilder.Entity<Book>().HasData(book2);

        var book1Copy1 = new Copy
        {
            Id = 1,
            BookId = 1,
            Condition = Condition.Pristine,
        };
        var book1Copy2 = new Copy
        {
            Id = 2,
            BookId = 1,
            Condition = Condition.Good,
        };
        var book2Copy1 = new Copy
        {
            Id = 3,
            BookId = 2,
            Condition = Condition.Average,
        };

        modelBuilder.Entity<Copy>().HasOne(copy => copy.Book).WithMany(book => book.Copies);
        modelBuilder.Entity<Copy>().HasMany(copy => copy.LoanHistory).WithOne(loan => loan.Copy);
        modelBuilder.Entity<Copy>().HasData(book1Copy1);
        modelBuilder.Entity<Copy>().HasData(book1Copy2);
        modelBuilder.Entity<Copy>().HasData(book2Copy1);

        var member1 = new Member
        {
            Id = 1,
            Name = "Anastasia",
        };
        var member2 = new Member
        {
            Id = 2,
            Name = "Dani",
        };

        modelBuilder.Entity<Member>().HasMany(member => member.LoanHistory).WithOne(loan => loan.Member);
        modelBuilder.Entity<Member>().HasData(member1);
        modelBuilder.Entity<Member>().HasData(member2);

        var loan1 = new Loan
        {
            Id = 1,
            MemberId = 1,
            CopyId = 1,
            DateBorrowed = DateOnly.FromDateTime(DateTime.Today).AddDays(-20),
            DateDueBack = DateOnly.FromDateTime(DateTime.Today).AddDays(-6),
            DateReturned = DateOnly.FromDateTime(DateTime.Today).AddDays(-8),
        };
        var loan2 = new Loan
        {
            Id = 2,
            MemberId = 1,
            CopyId = 3,
            DateBorrowed = DateOnly.FromDateTime(DateTime.Today).AddDays(-5),
            DateDueBack = DateOnly.FromDateTime(DateTime.Today).AddDays(9),
        };
        var loan3 = new Loan
        {
            Id = 3,
            MemberId = 2,
            CopyId = 1,
            DateBorrowed = DateOnly.FromDateTime(DateTime.Today).AddDays(-4),
            DateDueBack = DateOnly.FromDateTime(DateTime.Today).AddDays(10),
        };

        modelBuilder.Entity<Loan>().HasOne(loan => loan.Member).WithMany(member => member.LoanHistory);
        modelBuilder.Entity<Loan>().HasOne(loan => loan.Copy).WithMany(copy => copy.LoanHistory);
        modelBuilder.Entity<Loan>().HasData(loan1);
        modelBuilder.Entity<Loan>().HasData(loan2);
        modelBuilder.Entity<Loan>().HasData(loan3);
    }
}
