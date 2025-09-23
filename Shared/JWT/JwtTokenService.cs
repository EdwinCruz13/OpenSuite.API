using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Entidades.Seguridad.Auth;
using System.Data;

namespace Shared.JWT
{
    public class JwtTokenService
    {
        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenService"/> class using the specified JWT settings.
        /// </summary>
        /// <param name="jwtSettings">The configuration settings for generating and validating JWT tokens. This parameter must not be null.</param>
        public JwtTokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Genera un token basado en el nombre de usuario y los roles proporcionados.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public string GenerateToken(UsuarioAutenticado usuario)
        {


            //crerar claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.nUsuario),
                new Claim(ClaimTypes.NameIdentifier, usuario.Usuario),
            };

            // Agregar roles como claims
            foreach (var role in usuario.Perfiles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.nPerfil));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
               signingCredentials: creds
           );


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        /// <summary>
        /// valida el token generado
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsPrincipal ValidateToken(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = key
            }, out SecurityToken validatedToken);

            return principal;
        }
    }

}


