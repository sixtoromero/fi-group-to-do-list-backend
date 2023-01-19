using AutoMapper;
using fi_group.Application.DTO;
using fi_group.Application.Interface;
using fi_group.Domain.Interface;
using i_group.Transversal.Common;

namespace fi_group.Application.Main
{
    public class TaskApplication : ITaskApplication
    {
        private readonly ITaskDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<TaskApplication> _logger;

        public TaskApplication(ITaskDomain _Domain, IMapper mapper, IAppLogger<TaskApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> InsertAsync(TaskDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<fi_group.Domain.Entity.Task>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(TaskDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<fi_group.Domain.Entity.Task>(modelDto);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int ID)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DeleteAsync(ID);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<TaskDTO>> GetAsync(int ID)
        {
            var response = new Response<TaskDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);

                response.Data = _mapper.Map<TaskDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<TaskDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<TaskDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<TaskDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

    }
}