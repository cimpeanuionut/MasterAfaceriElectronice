using Applicatie.Models.Interfaces;
using MagazinOnline.Models.DTOs.FilterDTOs;
using MagazinOnline.Models.DTOs.VMDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applicatie.Web.Controllers
{
    [Route("[Controller]")]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService service;

        public ProductTypeController(IProductTypeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ProductTypeFilterDTO filter = null)
        {
            var list = await service.ListByFilterAsync(filter);
            return View(list);
        }

        [HttpGet]
        [Route("New")]
        public virtual IActionResult New()
        {
            var dto = new ProductTypeVMDTO();
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public virtual async Task<IActionResult> New(ProductTypeVMDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            await service.CreateEntityAsync(dto);
            return View("Index", new List<ProductTypeVMDTO>(await service.ListByFilterAsync()));           
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public virtual async Task<IActionResult> Edit(int id)
        {
            var model = await service.GetEntityAsync(id);
            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public virtual async Task<IActionResult> Edit(int id, ProductTypeVMDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            await service.UpdateEntityAsync(id, dto);
            return View("Index", new List<ProductTypeVMDTO>(await service.ListByFilterAsync()));           
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public virtual async Task<JsonResult> Delete(int id)
        {
            await service.DeleteEntityAsync(id);
            return Json(new { success = true, message = "Delete success" });
        }
    }
}
