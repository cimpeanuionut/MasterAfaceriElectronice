using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProiectMaster.Services
{
    public class ProductService : IProductService
    {
        private const string
            imgFolderName = "img";

        private readonly IRepository<Product, int> productRep;
        private readonly IRepository<ProductType, int> productTypeRep;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductService(IRepository<Product, int> productRep, IRepository<ProductType, int> productTypeRep, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            this.productRep = productRep;
            this.productTypeRep = productTypeRep;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }

        public void AddProduct(ProductVM dto)
        {
            SaveImage(dto);

            var entity = mapper.Map<Product>(dto);
            productRep.Add(entity);
        }

        public void DeleteProduct(int id)
        {
            var entity = productRep.GetInstance(id);

            if (!string.IsNullOrWhiteSpace(entity.ImagePath))
            {
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, entity.ImagePath);

                if (File.Exists(filePath))
                    File.Delete(filePath);
            }

            productRep.Delete(entity);
        }

        public IEnumerable<ProductVM> GetAllProducts()
        {
            var list = productRep.GetAll();
            return mapper.Map<List<ProductVM>>(list);
        }

        public ProductVM GetProduct(int id)
        {
            var entity = productRep.GetInstance(id);
            return mapper.Map<ProductVM>(entity);
        }        

        public void UpdateProduct(int id, ProductVM dto)
        {
            var entity = productRep.GetInstance(id);

            var oldFileRelativePath = entity.ImagePath;
            if (dto.ProducImage == null)
                dto.ImagePath = oldFileRelativePath;
            else
            {
                if (!string.IsNullOrWhiteSpace(oldFileRelativePath))
                {
                    var olfFileFullPath = Path.Combine(hostingEnvironment.WebRootPath, oldFileRelativePath);
                    if (File.Exists(olfFileFullPath))
                        File.Delete(olfFileFullPath);
                }

                SaveImage(dto);
            }

            mapper.Map(dto, entity);
            productRep.Update(entity);
        }

        public List<IdNameDto> GetProductTypes()
        {
            return productTypeRep.GetAll().Select(e => new IdNameDto(e.Id, e.Name)).ToList();
        }

        private void SaveImage(ProductVM dto)
        {
            if (dto.ProducImage == null)
                return;

            var imgFolderPath = Path.Combine(hostingEnvironment.WebRootPath, imgFolderName);

            if (!Directory.Exists(imgFolderPath))
                Directory.CreateDirectory(imgFolderPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(dto.ProducImage.FileName);
            var imgFullPath = Path.Combine(imgFolderPath, fileName);

            using (var fileStream = new FileStream(imgFullPath, FileMode.Create))
                dto.ProducImage.CopyTo(fileStream);

            dto.ImagePath = Path.Combine(imgFolderName, fileName);
        }
    }
}
