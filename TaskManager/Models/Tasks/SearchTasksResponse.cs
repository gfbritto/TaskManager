using Newtonsoft.Json;

namespace TaskManager.Models.Tasks
{
    public class SearchTasksResponse
    {
        [JsonProperty("")]
        public string Message { get; set; }

        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
