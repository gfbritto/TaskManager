using Newtonsoft.Json;

namespace TaskManager.Models.Tasks
{
    public class DeleteTaskPayload
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
