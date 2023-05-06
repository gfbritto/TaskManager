using RestEase;
using TaskManager.Models.Tasks;

namespace TaskManager.Services
{
    [Header("content-type", "application/json")]
    public interface ITaskService
    {
        [Post("/task/new/")]
        Task<string> AddNewTask([Header("Authorization")] string authorization, [Body] NewTaskPayload payload);

        [Post("/task/search/")]
        Task<SearchTasksResponse> SearchTasks([Header("Authorization")] string authorization);

        [Put("/task/update/")]
        Task<string> UpdateTask([Header("Authorization")] string authorization, [Body] UpdateTaskPayload payload);

        //[Post("/task/edit/")]
        //Task<TaskResult> EditTask([Body] EditTaskPayload payload);

        [Delete("/task/delete/")]
        Task<string> DeleteTask([Header("Authorization")] string authorization, [Body] DeleteTaskPayload payload);
    }
}
