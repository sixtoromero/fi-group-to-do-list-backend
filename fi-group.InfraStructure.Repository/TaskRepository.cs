using fi_group.InfraStructure.Interface;
using fi_group.InfraStructure.Repository.Persistence;
using Microsoft.EntityFrameworkCore;

namespace fi_group.InfraStructure.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext context;
        public TaskRepository(TaskDbContext _context)
        {
            context = _context;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            var resp = await context.Tasks.FirstOrDefaultAsync(g => g.Id == ID);
            if (resp is null)
            {
                return false;
            }

            context.Remove(resp);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Domain.Entity.Task>> GetAllAsync()
        {
            IEnumerable<Domain.Entity.Task> resp = await context.Tasks.OrderBy(g => g.NameTask).OrderBy(o => o.Completed).ToListAsync();
            return resp;
        }

        public async Task<Domain.Entity.Task> GetAsync(int ID)
        {
            return await context.Tasks.FirstOrDefaultAsync(g => g.Id == ID);
        }

        public async Task<bool> InsertAsync(Domain.Entity.Task model)
        {
            context.Add(model);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Domain.Entity.Task model)
        {            
            context.Update(model);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
