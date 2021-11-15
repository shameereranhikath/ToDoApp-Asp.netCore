using Domain.Entities;
using System.Collections.Generic;


namespace Domain.Interfaces
{
    public interface IToDo
    {
        IEnumerable<ToDo> GetAllToDos();
        ToDo GetToDo(int Id);
        void Insert(ToDo todo);
        void Update(ToDo todo);
        void Delete(ToDo todo);
        void Save();
    }
}
