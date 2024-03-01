using Bookish.Enums;
using Bookish.Models.Data;

namespace Bookish;

public class Library
{
    public List<Book> Books { get; set; } = [];
    public List<Copy> Copies { get; set; } = [];
    public List<Loan> Loans { get; set; } = [];
    public List<Member> Members { get; set; } = [];

    public Library()
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

        Books.Add(book1);
        Books.Add(book2);

        var book1Copy1 = new Copy
        {
            Id = 1,
            Book = book1,
            Condition = Condition.Pristine,
        };
        var book1Copy2 = new Copy
        {
            Id = 2,
            Book = book1,
            Condition = Condition.Good,
        };
        var book2Copy1 = new Copy
        {
            Id = 3,
            Book = book2,
            Condition = Condition.Average,
        };

        book1.Copies.Add(book1Copy1);
        book1.Copies.Add(book1Copy2);
        book2.Copies.Add(book2Copy1);

        Copies.Add(book1Copy1);
        Copies.Add(book1Copy2);
        Copies.Add(book2Copy1);

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

        Members.Add(member1);
        Members.Add(member2);

        var loan1 = new Loan
        {
            Id = 1,
            Member = member1,
            Copy = book1Copy1,
            DateBorrowed = DateOnly.FromDateTime(DateTime.Today).AddDays(-20),
            DateDueBack = DateOnly.FromDateTime(DateTime.Today).AddDays(-6),
            DateReturned = DateOnly.FromDateTime(DateTime.Today).AddDays(-8),
        };
        var loan2 = new Loan
        {
            Id = 2,
            Member = member1,
            Copy = book2Copy1,
            DateBorrowed = DateOnly.FromDateTime(DateTime.Today).AddDays(-5),
            DateDueBack = DateOnly.FromDateTime(DateTime.Today).AddDays(9),
        };
        var loan3 = new Loan
        {
            Id = 3,
            Member = member2,
            Copy = book1Copy1,
            DateBorrowed = DateOnly.FromDateTime(DateTime.Today).AddDays(-4),
            DateDueBack = DateOnly.FromDateTime(DateTime.Today).AddDays(10),
        };

        member1.LoanHistory.Add(loan1);
        book1Copy1.LoanHistory.Add(loan1);
        member1.LoanHistory.Add(loan2);
        book2Copy1.LoanHistory.Add(loan2);
        member2.LoanHistory.Add(loan3);
        book1Copy1.LoanHistory.Add(loan3);

        Loans.Add(loan1);
        Loans.Add(loan2);
        Loans.Add(loan3);
    }
}
