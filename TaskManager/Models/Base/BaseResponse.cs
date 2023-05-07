using Newtonsoft.Json;

namespace TaskManager.Models.Base
{
    public class BaseResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
