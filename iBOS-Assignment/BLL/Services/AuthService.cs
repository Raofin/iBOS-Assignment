using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;

namespace iBOS_Assignment.BLL.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;

        // Constructor for the AuthService class, which injects an instance of IConfiguration.
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        // Generate an authentication token using JWT based on the provided configuration.
        public string Generate()
        {
            // Create a security key using the secret key from the app's configuration.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // Create credentials for signing the token using HMAC-SHA256 algorithm.
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define claims that will be included in the JWT token.
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "Raofin")
            };

            // Create a JWT token with specified issuer, audience, claims, expiration, and signing credentials.
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15), // Token expiration time.
                signingCredentials: credentials);

            // Serialize the token to a string and return it.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}