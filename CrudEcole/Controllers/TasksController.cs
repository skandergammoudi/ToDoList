using Microsoft.AspNetCore.Mvc;
using CrudEcole.Models;
using CrudEcole.Data;
using System.Linq;

namespace CrudEcole.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.TaskItems.ToList();
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.TaskItems.Add(taskItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }


        public IActionResult Edit(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Update(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            _context.TaskItems.Remove(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult StartTask(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            if (!task.StartTime.HasValue)
            {
                task.StartTime = DateTime.Now;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult FinishTask(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            if (!task.EndTime.HasValue)
            {
                task.EndTime = DateTime.Now;
                task.IsCompleted = true;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
