using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MagazinOnline.Models.DTOs.VMDTOs
{
    public class ProductTypeVMDTO
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        [DisplayName("Product type name")]
        public string Name { get; set; }
    }
}
