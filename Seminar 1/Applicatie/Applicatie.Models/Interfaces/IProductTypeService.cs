using MagazinOnline.Models.DTOs.FilterDTOs;
using MagazinOnline.Models.DTOs.VMDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applicatie.Models.Interfaces
{
    public interface IProductTypeService
    {
        Task<List<ProductTypeVMDTO>> ListByFilterAsync(ProductTypeFilterDTO filter = null);
        Task<ProductTypeVMDTO> GetEntityAsync(int id);
        Task CreateEntityAsync(ProductTypeVMDTO dto);
        Task UpdateEntityAsync(int id, ProductTypeVMDTO dto);
        Task DeleteEntityAsync(int id);
    }
}
