using System.ComponentModel.DataAnnotations;

namespace FoodieAPI.Domain.DTO.Requests;

public class CreateEmailTemplateDto(string emailTemplateName, string emailTemplateContent)
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string EmailTemplateName { get; set; } = emailTemplateName;

    [Required] public string EmailTemplateContent { get; set; } = emailTemplateContent;
}