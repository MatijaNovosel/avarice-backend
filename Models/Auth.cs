using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace avarice_backend.Models
{
  public class LoginResult
  {
    public string Token { get; set; }
    public bool Result { get; set; }
    public List<string> Errors { get; set; }
  }

  public class RegisterResult
  {
    public bool Result { get; set; }
    public List<string> Errors { get; set; }
  }

  public class RegistrationModel
  {
    [Required]
    [MinLength(5)]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Password must meet requirements")]
    public string Password { get; set; }
  }

  public class LoginModel
  {
    public string Email { get; set; }
    public string Password { get; set; }
  }
}