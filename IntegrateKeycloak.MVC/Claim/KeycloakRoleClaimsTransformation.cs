using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;
using System.Security.Claims;


namespace IntegrateKeycloak.MVC.Claim
{
    public class KeycloakRoleClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity;
            var realmAccessClaim = identity.FindFirst("realm_access");

            if (realmAccessClaim != null)
            {
                // Assuming the claim value is a JSON object with a "roles" array
                var rolesObj = JObject.Parse(realmAccessClaim.Value);
                var roles = rolesObj["roles"]?.ToObject<List<string>>();
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        // Add each role as a new claim of type "role"
                        identity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Role, role));
                    }
                }
            }

            return Task.FromResult(principal);
        }
    }
}
