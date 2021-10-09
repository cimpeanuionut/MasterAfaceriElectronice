using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using System.Collections.Generic;

namespace ProiectMaster.Models.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductVM> GetAllProducts();
        ProductVM GetProduct(int id);
        void AddProduct(ProductVM dto);
        void UpdateProduct(int id, ProductVM dto);
        void DeleteProduct(int id);
        List<IdNameDto> GetProductTypes();
    }
}
