using Microsoft.VisualBasic;

namespace FoodieAPI.Domain.DTO.Requests;

public class CreateUserAddressDto(
    string userAddress,
    string userAddressNumber,
    string? userAddressComplement,
    bool isDefault = false)
{
    public string UserAddress { get; } = Strings.Trim(userAddress);
    public string UserAddressNumber { get; } = Strings.Trim(userAddressNumber);
    public string? UserAddressComplement { get; } = Strings.Trim(userAddressComplement ?? null);
    public bool IsDefault { get; } = isDefault;
}