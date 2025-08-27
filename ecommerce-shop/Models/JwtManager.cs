//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;

//public static class JwtManager
//{

//    private static readonly string Secret = "NguyenLeVanQuyenBiKhung123456789!!!!!";

//    // Tạo token HS256
//    public static string GenerateToken(string username, int userId, int expireMinutes = 60)
//    {
//        var key = Encoding.UTF8.GetBytes(Secret);
//        var tokenHandler = new JwtSecurityTokenHandler();

//        var tokenDescriptor = new SecurityTokenDescriptor
//        {
//            Subject = new ClaimsIdentity(new[]
//            {
//            new Claim(ClaimTypes.Name, username),
//            new Claim(ClaimTypes.NameIdentifier, userId.ToString())  
//        }),
//            Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
//            SigningCredentials = new SigningCredentials(
//                new SymmetricSecurityKey(key),
//                SecurityAlgorithms.HmacSha256Signature)
//        };

//        var token = tokenHandler.CreateToken(tokenDescriptor);
//        return tokenHandler.WriteToken(token);
//    }

//    // ⚠️ LỖ HỔNG: Cho phép xác thực JWT không chữ ký (alg: none)
//    public static ClaimsPrincipal GetPrincipal(string token)
//    {
//        try
//        {
//            var handler = new JwtSecurityTokenHandler();

//            // Custom xác thực chữ ký thủ công nếu có chữ ký
//            var validationParameters = new TokenValidationParameters
//            {
//                ValidateIssuer = false,
//                ValidateAudience = false,
//                ValidateLifetime = false,
//                ValidateIssuerSigningKey = false,
//                RequireSignedTokens = false, //  LỖ HỔNG CHÍNH
//                SignatureValidator = delegate (string jwt, TokenValidationParameters _) // Lỗi signature bị bỏ qua
//                {
//                    var jwtToken = new JwtSecurityToken(jwt);
//                    return jwtToken;
//                },
//                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
//                ClockSkew = TimeSpan.Zero

//            };

//            SecurityToken validatedToken;
//            return handler.ValidateToken(token, validationParameters, out validatedToken);
//        }
//        catch
//        {
//            return null;
//        }
//    }
//}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public static class JwtManager
{
    private static readonly string Secret = "NguyenLeVanQuyenBiKhung123456789!!!!!";

    // Tạo token HS256
    public static string GenerateToken(string username, int userId, int expireMinutes = 60)
    {
        var key = Encoding.UTF8.GetBytes(Secret);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static ClaimsPrincipal GetPrincipal(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Secret);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true, // Kiểm tra hạn token
                ValidateIssuerSigningKey = true, // Bắt buộc kiểm tra chữ ký
                RequireSignedTokens = true, // Yêu cầu token phải có chữ ký
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            return tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        }
        catch (Exception)
        {
            return null;
        }
    }
}


