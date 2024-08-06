namespace FoodieAPI.Domain;

public interface IDataEncryptionService
{
  string Hash(string toBeEncryptedText);
  bool Verify(string encryptedText, string rawText);
}
