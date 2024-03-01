using Bookish.Enums;

namespace Bookish.Models.Data;

public class Copy
{
    public int Id { get; set; }
    public required Book Book { get; set; }
    public Condition Condition { get; set; } = Condition.Pristine;
    public List<Loan> LoanHistory { get; set; } = [];
    public bool HasLiveLoan => LoanHistory.Any(loan => loan.DateReturned == null);
    public Loan? LiveLoan => LoanHistory.SingleOrDefault(loan => loan.DateReturned == null);
}
