namespace Bookish.Models.Data;

public class Member
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Loan> LoanHistory { get; set; } = [];
}
