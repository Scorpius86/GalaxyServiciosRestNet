using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Galaxy.API.Token.Model;
using Galaxy.API.Token.Models;
using Microsoft.IdentityModel.Tokens;


namespace Galaxy.API.Token.Security
{
  public class SecurityManager
  {
    private JwtSettings _settings = null;
    public SecurityManager(JwtSettings settings)
    {
      _settings = settings;
    }

        public AppUserAuth ValidateUser()
        {
            AppUserAuth ret = new AppUserAuth();
            ret = BuildUserAuthObject();
            return ret;
        }
        protected AppUserAuth BuildUserAuthObject()
        {
            AppUserAuth ret = new AppUserAuth();

            // Set User Properties
            ret.UserName = "Erick";
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid().ToString();

            // Set JWT bearer token
            ret.BearerToken = BuildJwtToken(ret);

            return ret;
        }

    protected string BuildJwtToken(AppUserAuth authUser)
    {
      SymmetricSecurityKey key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_settings.Key));

      // Create standard JWT claims
      List<Claim> jwtClaims = new List<Claim>();
      jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub,
          authUser.UserName));
      jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,
          Guid.NewGuid().ToString()));

      // Add custom claims
      jwtClaims.Add(new Claim("isAuthenticated",
          authUser.IsAuthenticated.ToString().ToLower()));
      jwtClaims.Add(new Claim("canAccessProducts",
          authUser.CanAccessProducts.ToString().ToLower()));
      jwtClaims.Add(new Claim("canAddProduct",
          authUser.CanAddProduct.ToString().ToLower()));
      jwtClaims.Add(new Claim("canSaveProduct",
          authUser.CanSaveProduct.ToString().ToLower()));
      jwtClaims.Add(new Claim("canAccessCategories",
          authUser.CanAccessCategories.ToString().ToLower()));
      jwtClaims.Add(new Claim("canAddCategory",
          authUser.CanAddCategory.ToString().ToLower()));

      // Create the JwtSecurityToken object
      var token = new JwtSecurityToken(
        issuer: _settings.Issuer,
        audience: _settings.Audience,
        claims: jwtClaims,
        notBefore: DateTime.UtcNow,
        expires: DateTime.UtcNow.AddMinutes(
            _settings.MinutesToExpiration),
        signingCredentials: new SigningCredentials(key,
                    SecurityAlgorithms.HmacSha256)
      );

      // Create a string representation of the Jwt token
      return new JwtSecurityTokenHandler().WriteToken(token); ;
    }
  }
}
