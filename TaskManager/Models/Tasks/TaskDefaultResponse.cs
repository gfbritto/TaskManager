using Newtonsoft.Json;

namespace TaskManager.Models.Tasks
{
    public class TaskDefaultResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
