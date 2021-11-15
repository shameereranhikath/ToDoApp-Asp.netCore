using DataAccess.EFCore.AppDbContext;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EFCore.Repository
{
    public class ToDoRepository : IToDo
    {
        private readonly TodoDbContext _context;
        public ToDoRepository(TodoDbContext context)
        {
            _context = context;

        }
        public void Delete(ToDo todo)
        {
            _context.ToDos.Remove(todo);
        }

        public IEnumerable<ToDo> GetAllToDos()
        {
            return _context.ToDos.ToList();
        }

        public ToDo GetToDo(int Id)
        {
            return (ToDo)_context.ToDos.Where(m => m.Id == Id);

        }

        public void Insert(ToDo todo)
        {
            _context.ToDos.Add(todo);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ToDo todo)
        {
            _context.ToDos.Update(todo);
        }
    }
}
