using System;
using System.ComponentModel.DataAnnotations;

namespace workLogger.DTOs
{
  public class UserSendDto
  {
    [StringLength(60)]
    public string FirstName { get; set; }
    [StringLength(60)]
    public string LastName { get; set; }
    [StringLength(60)]
    public string Email { get; set; }
    [StringLength(60)]
    public string Password { get; set; }
  }
}
