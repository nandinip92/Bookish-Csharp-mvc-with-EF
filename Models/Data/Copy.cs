using System.ComponentModel.DataAnnotations.Schema;
using Bookish.Enums;

namespace Bookish.Models.Data;

public class Copy
{
    public int Id { get; set; }

    public required int BookId { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; } = null!;

    public Condition Condition { get; set; } = Condition.Pristine;

    public List<Loan> LoanHistory { get; set; } = [];
}
