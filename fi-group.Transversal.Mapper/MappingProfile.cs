using AutoMapper;
using fi_group.Application.DTO;

namespace fi_group.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<fi_group.Domain.Entity.Task, TaskDTO>().ReverseMap();
        }
    }
}
