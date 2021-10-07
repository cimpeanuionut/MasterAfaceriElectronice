using AutoMapper;
using MagazinOnline.Models.DTOs.VMDTOs;
using MagazinOnline.Models.Entities;

namespace MagazinOnline.Models
{
    public static class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductType, ProductTypeVMDTO>();
                cfg.CreateMap<ProductTypeVMDTO, ProductType>();              
            });

            return config.CreateMapper();
        }
    }
}
