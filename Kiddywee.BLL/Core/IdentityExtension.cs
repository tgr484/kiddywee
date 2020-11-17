using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Kiddywee.BLL.Core
{
    public static class IdentityExtension
    {
        public static Guid GetOrganizationId(this IIdentity identity)
            => new Guid(((ClaimsIdentity)identity).FindFirst(Constants.CLAIM_ORGANIZATIONID).Value); 
    }
}
