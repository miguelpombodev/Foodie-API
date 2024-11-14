using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests;

public class CartProducts
{
  [Required] public Guid ProductId { get; set; }

  [Required] public int ProductQuantity { get; set; }
}