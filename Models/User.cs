using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace workLogger.Models
{
  public class User
  {
    [Required]
    [Key]
    public int Id { get; set; }

    // [Required]
    [StringLength(60)]
    public string FirstName { get; set; }

    // [Required]
    [StringLength(60)]
    public string LastName { get; set; }

    // [Required]
    [StringLength(60)]
    public string Email { get; set; }

    // [Required]
    [StringLength(60)]
    public string Password { get; set; }

    public List<Task> Tasks { get; set; }
  }
}
