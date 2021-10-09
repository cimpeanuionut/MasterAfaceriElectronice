using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMaster.Web.Controllers
{
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = service.GetAllProducts();
            return View(list);
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            var dto = new ProductVM();
            dto.ProductTypes = service.GetProductTypes();
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult New(ProductVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                dto.ProductTypes = service.GetProductTypes();
                return View(dto);
            }

            service.AddProduct(dto);

            return View("Index", service.GetAllProducts());
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var dto = service.GetProduct(id);
            dto.ProductTypes = service.GetProductTypes();
            return View(dto);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, ProductVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                dto.ProductTypes = service.GetProductTypes();
                return View(dto);
            }

            service.UpdateProduct(id, dto);

            return View("Index", service.GetAllProducts());
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            service.DeleteProduct(id);
            return Json(new { success = true, message = "Delete success" });
        }
    }
}
