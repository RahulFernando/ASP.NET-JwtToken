namespace JwtToken.Models
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User() { Id = 1, Username = "jason_admin", EmailAddress = "jasonadmin@gmai.com", Role = "Administrator", GivenName = "Jason", Surname = "Bryatt", Password = "admin_pass"},
            new User() { Id = 2, Username = "elyse_seller", EmailAddress = "eslyseseller@gmai.com", Role = "Seller", GivenName = "Elyse", Surname = "Seller", Password = "elyse_pass"},
        };
    }
}
