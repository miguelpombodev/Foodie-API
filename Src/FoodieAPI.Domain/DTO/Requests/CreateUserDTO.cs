using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests
{
  public class CreateUserDTO(string name, string phone, string email, string cPF)
  {
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Name { get; set; } = name;

    [Required]
    [StringLength(12)]
    public string Phone { get; set; } = phone;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = email;

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CPF { get; set; } = cPF;
  }
}