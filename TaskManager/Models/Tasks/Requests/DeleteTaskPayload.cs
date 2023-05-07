using Newtonsoft.Json;

namespace TaskManager.Models.Tasks.Request
{
    public class DeleteTaskPayload
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
