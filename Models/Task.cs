using System.ComponentModel.DataAnnotations;

namespace workLogger.Models
{
  public class Task
  {
    [Required]
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public long ProjectNumber { get; set; }
    public float HoursAvailableToWork { get; set; }
    public float HoursWorked { get; set; }
    public float HoursRemaining { get; set; }
    public string Notes { get; set; }
    public int NumberOfReviews { get; set; }
    public int ReviewHours { get; set; }
    public int HoursRequiredByBim { get; set; }
    public bool IsComplete { get; set; }
    public int UserId { get; set; }
  }
}