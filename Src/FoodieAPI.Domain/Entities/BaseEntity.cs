namespace FoodieAPI.Domain.Entities
{
  public abstract class BaseEntity
  {
    public BaseEntity()
    {
      Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
  }
}