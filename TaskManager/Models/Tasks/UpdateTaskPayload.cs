namespace TaskManager.Models.Tasks
{
    public class UpdateTaskPayload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Realized { get; set; }
    }
}
