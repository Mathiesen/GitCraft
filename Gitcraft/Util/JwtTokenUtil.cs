using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Gitcraft.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Gitcraft.Util;

public class JwtTokenUtil
{
    public string GenerateToken(string userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("O4iQZDLQrwHQvc5ku2P84gjwpGYnkwNn");
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("username", userName) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
    }
}