using Newtonsoft.Json;

namespace TaskManager.Models.Tasks.Request
{
    public class NewTaskPayload
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
