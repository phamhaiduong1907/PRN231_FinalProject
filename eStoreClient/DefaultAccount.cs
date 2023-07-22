using Newtonsoft.Json;
namespace eStoreClient
{
    public class DefaultAccount
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("Role")]
        public string Role { get; set; }

        public DefaultAccount() { }

        public DefaultAccount(string email, string password, string role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}