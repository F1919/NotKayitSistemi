using AutoMapper;
using NotKayitSistemi.Models.Entities;
using NotKayitSistemi.Models.ViewModels;

namespace NotKayitSistemi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OgrenciTml, OgrenciTmlViewModel>();
        }
    }
}
