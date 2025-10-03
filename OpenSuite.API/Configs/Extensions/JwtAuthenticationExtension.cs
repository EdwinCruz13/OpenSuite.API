using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenSuite.API.Tools.Responses;
using Shared.JWT;
using System.Text;

namespace OpenSuite.API.Extensions
{
    /// <summary>
    /// anade la autenticacion JWT al proyecto
    /// </summary>
    public static class JwtAuthenticationExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("AuthConfigurationKey").Get<JwtSettings>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        // Evita la respuesta por defecto (401 vacío)
                        context.HandleResponse();

                        // Retorna una respuesta JSON personalizada
                        var response = new ApiResponse<string>(
                            errorMessage: "No tienes autorización para acceder a este recurso. Autenticación requerida!!!",
                            code: StatusCodes.Status401Unauthorized,
                            status: ResponseStatus.Failure
                        );

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        return context.Response.WriteAsync(
                            System.Text.Json.JsonSerializer.Serialize(response)
                        );
                    }
                };
            });

            return services;
        }
    }
}
