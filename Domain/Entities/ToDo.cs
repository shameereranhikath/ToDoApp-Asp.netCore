using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public String Content { get; set; }
    }
}
