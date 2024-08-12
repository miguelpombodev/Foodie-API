using System;
using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests
{
  public class AuthenticateUserDTO(string email)
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = email;
  }
};

