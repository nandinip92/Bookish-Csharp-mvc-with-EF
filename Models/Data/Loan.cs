using System.ComponentModel.DataAnnotations.Schema;
using Bookish.Constants;

namespace Bookish.Models.Data;

public class Loan
{
    public int Id { get; set; }

    public required int MemberId { get; set; }

    [ForeignKey("MemberId")]
    public Member Member { get; set; } = null!;

    public required int CopyId { get; set; }

    [ForeignKey("CopyId")]
    public Copy Copy { get; set; } = null!;

    public DateOnly DateBorrowed { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    public DateOnly DateDueBack { get; set; } = DateOnly.FromDateTime(DateTime.Today).AddDays(LoanConstants.DefaultLoanLength);

    public DateOnly? DateReturned { get; set; }
}
