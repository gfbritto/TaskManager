using Newtonsoft.Json;
using TaskManager.Models.Base;

namespace TaskManager.Models.User
{
    public class UserLoginResponse : BaseResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }
    }
}
