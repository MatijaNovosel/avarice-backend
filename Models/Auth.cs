using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fin_app_backend.Models
{
  public class AuthResultModel
  {
    public string Token { get; set; }
    public bool Result { get; set; }
    public List<string> Errors { get; set; }
  }

  public class RegistrationModel
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
  }
}