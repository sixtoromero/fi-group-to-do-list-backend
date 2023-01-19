using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fi_group.Application.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string NameTask { get; set; }
        public bool Completed { get; set; }
    }
}
