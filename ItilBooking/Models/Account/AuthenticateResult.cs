namespace ItilBooking.Models.Account
{
    public class AuthenticateResult
    {
        public string Login { get; set; }
        public bool IsSuccses { get; set; }

        public string ErrorDescription { get; set; }
    }
}
