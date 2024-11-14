namespace FoodieAPI.Domain.Entities
{
  public class StoreType
  {
    public StoreType(int id, string name, string avatar, string avatarLongImage, DateTime createdAt, DateTime updatedAt)
    {
      Id = id;
      Name = name;
      Avatar = avatar;
      AvatarLongImage = avatarLongImage;
      CreatedAt = createdAt;
      UpdatedAt = updatedAt;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string? Avatar { get; set; }
    public string? AvatarLongImage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}