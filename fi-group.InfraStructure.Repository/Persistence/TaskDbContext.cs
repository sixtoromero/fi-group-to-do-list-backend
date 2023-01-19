using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fi_group.InfraStructure.Repository.Persistence
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<fi_group.Domain.Entity.Task>? Tasks { get; set; }

    }
}
