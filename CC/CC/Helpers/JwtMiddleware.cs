using CC.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CC.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings appSettings; 

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
            this._next = next;
        }

        public async Task Invoke(HttpContext context, UserRepository userRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, token, userRepository);

            await _next(context); 
        }

        public void attachUserToContext(HttpContext httpContext, string token, UserRepository userRepository)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

               

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var userRole = jwtToken.Claims.First(x => x.Type== "role").Value;

                httpContext.Items["User"] = userRepository.Get(new Queries.UserQuery { userId = userId }).First();
            } catch
            {

            }
        }

    }
}
