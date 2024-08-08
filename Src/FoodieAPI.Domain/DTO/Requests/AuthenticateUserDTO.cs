using System;
using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests;

public class AuthenticateUserDTO
{
  [Required]
  [EmailAddress]
  public string userEmail;
}
