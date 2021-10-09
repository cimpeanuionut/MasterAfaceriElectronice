using System.ComponentModel.DataAnnotations;

namespace ProiectMaster.Models.DTOs.VM
{
    public class ProductTypeVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]        
        public string Name { get; set; }
    }
}
