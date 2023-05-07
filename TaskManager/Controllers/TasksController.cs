using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using TaskManager.Models.Tasks;
using TaskManager.Models.Tasks.Request;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;


        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var authorization = User.FindFirstValue(ClaimTypes.Authentication);
            var taskResponse = await _taskService.SearchTasks(authorization);

            if (taskResponse.IsSuccessStatusCode)
            {
                try
                {
                    var content = await taskResponse.Content.ReadAsStringAsync();
                    if (content.StartsWith("{\"message\""))
                    {
                        return View(new List<TaskModel>());
                    }
                    var tasks = JsonConvert.DeserializeObject<List<TaskModel>>(content);

                    return View(tasks);
                }
                catch (Exception ex)
                {
                    return View(new List<TaskModel>());
                }

            }
            return View(new List<TaskModel>());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await FindTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] NewTaskPayload task)
        {
            if (ModelState.IsValid)
            {
                var authorization = User.FindFirstValue(ClaimTypes.Authentication);
                var response = await _taskService.AddNewTask(authorization, task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await FindTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Realized")] TaskModel task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            var isInvalidModel = task == null || string.IsNullOrEmpty(task.Name) || task.Realized == null || task.Realized > 2;
            if (!isInvalidModel)
            {
                try
                {
                    var taskPayload = new UpdateTaskPayload
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Realized = (int)task.Realized
                    };
                    var authorization = User.FindFirstValue(ClaimTypes.Authentication);
                    await _taskService.UpdateTask(authorization, taskPayload);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await FindTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = FindTaskById(id);
            if (task != null)
            {
                var authorization = User.FindFirstValue(ClaimTypes.Authentication);
                var resopnse = await _taskService.DeleteTask(authorization, new DeleteTaskPayload { Id = id });
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<TaskModel?> FindTaskById(int? id)
        {
            var authorization = User.FindFirstValue(ClaimTypes.Authentication);
            var taskResponse = await _taskService.SearchTasks(authorization);

            if (taskResponse.IsSuccessStatusCode)
            {
                try
                {
                    var content = await taskResponse.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<List<TaskModel>>(content);

                    return tasks.FirstOrDefault(task => task.Id == id);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }
    }
}
