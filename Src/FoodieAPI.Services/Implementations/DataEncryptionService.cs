using System.Security.Cryptography;
using FoodieAPI.Domain;

namespace FoodieAPI.Services;

public class DataEncryptionService : IDataEncryptionService
{
  private readonly int SaltSize = 128 / 8;
  private readonly int KeySize = 256 / 8;
  private readonly int Iterations = 10000;
  private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
  private const char Delimiter = ';';


  public string Hash(string toBeEncryptedText)
  {
    var salt = RandomNumberGenerator.GetBytes(SaltSize);
    var hash = Rfc2898DeriveBytes.Pbkdf2(toBeEncryptedText, salt, Iterations, _hashAlgorithmName, KeySize);

    return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
  }

  public bool Verify(string encryptedText, string rawText)
  {
    var elements = encryptedText.Split(Delimiter);
    var salt = Convert.FromBase64String(elements[0]);
    var hash = Convert.FromBase64String(elements[1]);

    var hashInput = Rfc2898DeriveBytes.Pbkdf2(encryptedText, salt, Iterations, _hashAlgorithmName, KeySize);

    return CryptographicOperations.FixedTimeEquals(hash, hashInput);
  }
}
