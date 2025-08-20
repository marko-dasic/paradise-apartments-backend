using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Apartment.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using API.Core.TokenStorage;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.AspNetCore.Http;

namespace API.Core
{
    public class JwtManager
    {
        private readonly ApartmentContext _context;
        private readonly JwtSettings _settings;
        private readonly ITokenStorage _storage;

        public JwtManager(ApartmentContext context, JwtSettings settings, ITokenStorage storage)
        {
            _settings = settings;
            _context = context;
            this._storage = storage;
        }

        public string MakeToken(string email, string password)
        {
            var user = _context.Users.Include(x => x.UseCases).FirstOrDefault(x => x.Email == email && x.IsActivated);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }


           /* var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!valid)
            {
                throw new UnauthorizedAccessException();
            }*/

            //var useCases = _context.UserUseCase.Where(x => x.UserId == user.Id).Select(x => x.UseCaseId);

            var actor = new JwtUser
            {
                Id = user.Id,
                UseCasesIds = user.UseCases.Select(x => x.UseCaseId).ToList(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone
            };

            var tokenId = Guid.NewGuid().ToString();
            _storage.AddToken(tokenId);


            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCasesIds)),
                new Claim("Email", user.Email),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Phone", user.Phone),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string RefreshToken(string token)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_settings.SecretKey);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;

                // Dohvati vrijeme isteka tokena
                var expirationDate = jwtToken.ValidTo;

                // Postavi novi datum isteka tokena (trenutno vrijeme + 30 minuta)
                var newExpirationDate = DateTime.UtcNow.AddMinutes(_settings.Minutes);

                // Ako je novi datum isteka tokena manji od originalnog, nemoj mijenjati token
                if (newExpirationDate <= expirationDate)
                {
                    return token;
                }

                // Generiraj novi token s promijenjenim datumom isteka
                var newJwtToken = new JwtSecurityToken(
                    issuer: jwtToken.Issuer,
                //    audience: "Any",
                    claims: principal.Claims,
                    notBefore: jwtToken.ValidFrom,
                    expires: newExpirationDate,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );

                var newToken =  new JwtSecurityTokenHandler().WriteToken(newJwtToken);

                return newToken;
            }
            catch (SecurityTokenException)
            {
                // Ako token nije ispravan, možete ovdje obraditi odgovarajuću grešku.
                // Na primjer, baciti iznimku ili vratiti null.
                return null;
            }
        }
    }
}

