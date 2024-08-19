using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests;

public class CreateBannerDto(string bannerName, string bannerUrl)
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string BannerName { get; set; } = bannerName;
    
    [Required]
    [StringLength(200, MinimumLength = 3)]
    [Url]
    public string BannerUrl { get; set; } = bannerUrl;
}