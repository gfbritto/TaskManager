using Newtonsoft.Json;

namespace TaskManager.Models.User.Requests
{
    public class UserAuth
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
