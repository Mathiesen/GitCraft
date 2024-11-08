using System.Security.Cryptography;
using System.Text;

namespace Gitcraft.Util;

public class HashUtil
{
    private int _keySize = 64;
    private int _iterations = 10000;
    private HashAlgorithmName _algorithm = HashAlgorithmName.SHA512;
    
    public (string hash, string salt) GenerateHash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(_keySize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _algorithm,
            _keySize);
        
        return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
    }
    
    public bool VerifyHash(string password, string storedHash, string storedSalt)
    {
        var saltBytes = Convert.FromBase64String(storedSalt);

        var hashBytes = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            saltBytes,
            _iterations,
            _algorithm,
            _keySize);

        return CryptographicOperations.FixedTimeEquals(
            hashBytes,
            Convert.FromBase64String(storedHash));
    }
}