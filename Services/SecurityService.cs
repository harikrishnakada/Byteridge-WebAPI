using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Services
{
    public interface ISecurityService
    {
        ClaimsPrincipal ValidateToken(HttpRequest request);
    };
    public class SecurityService: ISecurityService
    {
        public IConfiguration Configuration { get; }

        public SecurityService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ClaimsPrincipal ValidateToken(HttpRequest request)
        {
            var authorizationHeader = request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            string jwtToken = authorizationHeader.ToString().Replace("Bearer ", "");

            IdentityModelEventSource.ShowPII = true;

            var appSettingsSection = this.Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}
