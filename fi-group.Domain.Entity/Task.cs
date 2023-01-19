using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fi_group.Domain.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string NameTask { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }
}
