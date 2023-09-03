using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiClient.Entities;
using ApiClient.Helpers;
using ItBolt.Model.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiClient.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Felhasznalo felhasznalo);
        public int? ValidateJwtToken(string? token);
    }

    public class JwtUtils : IJwtUtils
    {
        private readonly AppSettings _appSettings;

        public JwtUtils(IOptions<AppSettings> appsettings)
        {
            _appSettings = appsettings.Value;

            if (string.IsNullOrEmpty(_appSettings.Secret))
            {
                throw new Exception("JWT secret not configured");
            }
        }

        public string GenerateJwtToken(Felhasznalo felhasznalo)
        {
            if (felhasznalo != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
                //Generate the token by properties
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", felhasznalo.id.ToString()) }),
                    Expires = DateTime.UtcNow.AddMinutes(180), // Valid for 3h
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            } else
            {
                return null;
            }
        }

        public int? ValidateJwtToken(string? token)
        {
            if (token == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII?.GetBytes(_appSettings.Secret!);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // ClockSkew = tokens expire excatly at token expiration time instead of 5 minutes
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var felhasznaloId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                //Returns the felhasznaloId if the validation was successful
                return felhasznaloId;
            }
            catch
            {
                //if validation wasn't successful
                return null;
            }
        }
    }
}
