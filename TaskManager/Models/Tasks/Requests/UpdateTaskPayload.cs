using Newtonsoft.Json;

namespace TaskManager.Models.Tasks.Request
{
    public class UpdateTaskPayload
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("realized")]
        public int Realized { get; set; }
    }
}
