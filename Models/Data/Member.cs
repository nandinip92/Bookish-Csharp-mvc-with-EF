namespace Bookish.Models.Data;

public class Member
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Loan> LoanHistory { get; set; } = [];
    public List<Loan> ActiveLoans => LoanHistory.Where(loan => loan.DateReturned == null).ToList();
}
