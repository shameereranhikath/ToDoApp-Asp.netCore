using cloudscribe.Pagination.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebUI.Controllers
{
    public class TodoController : Controller
    {
        private readonly IToDo _itodo;
        public TodoController(IToDo itodo)
        {
            _itodo = itodo;

        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            int ExcludeRecords = (pageNumber * pageSize) - pageSize;
            var todoModelData = _itodo.GetAllToDos();
            var todoModelDataExclude = todoModelData.Skip(ExcludeRecords).Take(pageSize);
            var result = new PagedResult<ToDo>();
            result.Data = todoModelDataExclude.ToList();
            result.TotalItems = todoModelData.Count();
            result.PageNumber = pageNumber;
            result.PageSize = pageSize;
            return View(result);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost, ActionName("Create")]
        public IActionResult Create(ToDo todoitem)
        {
            if (!ModelState.IsValid)
            {
                return View(todoitem);
            }
            _itodo.Insert(todoitem);
            _itodo.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var TodoData = _itodo.GetToDo(Id);

            if (TodoData == null)
            {
                return NotFound();
            }
            _itodo.Delete(TodoData);
            _itodo.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            return View(_itodo.GetToDo(Id));
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(ToDo todoitem)
        {
            //var TodoData = _itodo.GetToDo(Id);

            if (!ModelState.IsValid)
            {
                return View(todoitem);
            }
            _itodo.Update(todoitem);
            _itodo.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
