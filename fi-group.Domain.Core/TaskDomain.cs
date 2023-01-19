using fi_group.Domain.Interface;
using fi_group.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;

namespace fi_group.Domain.Core
{
    public class TaskDomain : ITaskDomain
    {
        private readonly ITaskRepository _Repository;
        public IConfiguration Configuration { get; }

        public TaskDomain(ITaskRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async Task<bool> InsertAsync(fi_group.Domain.Entity.Task model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(fi_group.Domain.Entity.Task model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await _Repository.DeleteAsync(ID);
        }

        public async Task<fi_group.Domain.Entity.Task> GetAsync(int ID)
        {
            return await _Repository.GetAsync(ID);
        }

        public async Task<IEnumerable<fi_group.Domain.Entity.Task>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
