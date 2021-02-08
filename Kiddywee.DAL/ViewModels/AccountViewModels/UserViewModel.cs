using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Kiddywee.DAL.ViewModels.AccountViewModels
{
    public class UserViewModel
    {
        public string UserEmail { get; set; }

        public string UserFullName { get; set; }

        public string UserId { get; set; }

        public string PersonId { get; set; }
        public UserViewModel(ClaimsPrincipal user, string personIdClaimName)
        {
            UserEmail = user.FindFirst(ClaimTypes.Email)?.Value;
            UserFullName = user.FindFirst(ClaimTypes.Name)?.Value;
            UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            PersonId = user.FindFirst(personIdClaimName)?.Value;
        }
    }
}
