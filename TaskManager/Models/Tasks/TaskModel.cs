using Newtonsoft.Json;

namespace TaskManager.Models.Tasks
{
    public class TaskModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("date")]
        public string? Date { get; set; }

        [JsonProperty("realized")]
        public int? Realized { get; set; }
    }

}
