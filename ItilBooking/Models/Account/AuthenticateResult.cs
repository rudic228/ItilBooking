using System.Security.Claims;

namespace ItilBooking.Models.Account
{
    public class AuthenticateResult
    {
        public ClaimsIdentity Identity { get; set; }
        public bool IsSuccses { get; set; }

        public string ErrorDescription { get; set; }
    }
}
