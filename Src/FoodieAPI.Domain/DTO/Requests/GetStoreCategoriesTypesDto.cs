using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FoodieAPI.Domain.DTO.Requests;


[DataContract]
public enum AvatarImageType
{
  [EnumMember(Value = "long")]
  LongImage,

  [EnumMember(Value = "short")]
  ShortImage,
}

