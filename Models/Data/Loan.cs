using Bookish.Constants;

namespace Bookish.Models.Data;

public class Loan
{
    public int Id { get; set; }
    public required Member Member { get; set; }
    public required Copy Copy { get; set; }
    public DateOnly DateBorrowed { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly DateDueBack { get; set; } = DateOnly.FromDateTime(DateTime.Today).AddDays(LoanConstants.DefaultLoanLength);
    public DateOnly? DateReturned { get; set; }
}
