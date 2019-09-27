using System.Security.Claims;
using System.Security.Principal;

namespace LoginWeb.Identity
{
    // Uses the IIdentity interface to create custom claims objects.
    public static class IdentityExtensions
    {
        // Claim declared in the builder, we can pass the value to use at the time of the user login to the system and
        // use it anywhere in our application.
        public static int GetId(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(CustomClaimTypes.Id);

            return claim?.Value != null ? int.Parse(claim.Value) : 0;
        }

        public static string GetName(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(CustomClaimTypes.Name);

            return claim?.Value ?? string.Empty;
        }

        public static string GetJob(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(CustomClaimTypes.Job);

            return claim?.Value ?? string.Empty;
        }

        // The objects created here are Customs Claims, here you can create other objects (bool, int, string, date etc).
        public static class CustomClaimTypes
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Job = "job";
        }
    }
}
