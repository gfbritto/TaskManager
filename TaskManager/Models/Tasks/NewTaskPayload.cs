using Newtonsoft.Json;

namespace TaskManager.Models.Tasks
{
    public class NewTaskPayload
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
