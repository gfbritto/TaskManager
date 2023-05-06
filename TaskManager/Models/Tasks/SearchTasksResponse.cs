namespace TaskManager.Models.Tasks
{
    public class SearchTasksResponse : TaskDefaultResponse
    {
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
