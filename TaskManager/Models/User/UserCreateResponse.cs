using Newtonsoft.Json;
using TaskManager.Models.Base;

namespace TaskManager.Models.User
{
    public class UserCreateResponse : BaseResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
