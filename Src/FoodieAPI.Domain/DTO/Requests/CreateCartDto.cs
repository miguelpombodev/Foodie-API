using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests;

public class CreateCartDto
{
  [Required] public IEnumerable<CartProducts> Products { get; set; } = new List<CartProducts>();

  [Required] public Guid StoreId { get; set; }
}