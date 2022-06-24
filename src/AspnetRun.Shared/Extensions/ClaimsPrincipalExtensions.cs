using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Shared.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId is null ? null : int.Parse(userId);
        }
    }
}
