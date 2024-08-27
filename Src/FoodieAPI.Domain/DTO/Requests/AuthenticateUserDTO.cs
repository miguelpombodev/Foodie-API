using System;
using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests
{
  public class AuthenticateUserDTO(string? email, string? phone)
  {
    [EmailAddress]
    public string? Email { get; set; } = email;

    [StringLength(20, ErrorMessage = "Username must have 12 characters")]
    public string? Phone { get; set; } = phone;
  }
};

