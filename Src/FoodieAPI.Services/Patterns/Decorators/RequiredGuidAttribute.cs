using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Services.Patterns.Decorators;

public class RequiredGuidAttribute : ValidationAttribute
{
  public RequiredGuidAttribute() => ErrorMessage = "{0} is required";
  public override bool IsValid(object? value) => value is Guid && !Guid.Empty.Equals(value);
}