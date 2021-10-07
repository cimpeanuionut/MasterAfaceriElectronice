using Applicatie.Models.Interfaces;
using AutoMapper;
using MagazinOnline.DataAcces;
using MagazinOnline.Models.DTOs.FilterDTOs;
using MagazinOnline.Models.DTOs.VMDTOs;
using MagazinOnline.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Applicatie.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IMapper mapper;
        private readonly IRepository<ProductType, int> modelRepository;

        public ProductTypeService(IMapper mapper, IRepository<ProductType, int> modelRepository)
        {
            this.mapper = mapper;
            this.modelRepository = modelRepository;
        }

        public async Task CreateEntityAsync(ProductTypeVMDTO dto)
        {
            var entity = mapper.Map<ProductType>(dto);
            await modelRepository.AddAsync(entity);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var entity = await modelRepository.GetInstanceAsync(id);

            if (entity == null)               
                return;      

            await modelRepository.DeleteAsync(entity);
        }

        public async Task<ProductTypeVMDTO> GetEntityAsync(int id)
        {
            var entity = await modelRepository.GetInstanceAsync(id);
            if (entity == null)
                return null;

            var dto = mapper.Map<ProductTypeVMDTO>(entity);          
            return dto;
        }

        public async Task<List<ProductTypeVMDTO>> ListByFilterAsync(ProductTypeFilterDTO filter = null)
        {
            if (filter == null)
                filter = new ProductTypeFilterDTO();

            var entityList = await modelRepository.GetAllAsync();

           return mapper.Map<List<ProductTypeVMDTO>>(entityList);      
        }

        public async Task UpdateEntityAsync(int id, ProductTypeVMDTO dto)
        {
            if (dto.Id == null || !id.Equals(dto.Id))            
                return;

            var entity = await modelRepository.GetInstanceAsync(id);
            if (entity == null)               
                return;

            mapper.Map(dto, entity);
            await modelRepository.UpdateAsync(entity);
        }
    }
}
