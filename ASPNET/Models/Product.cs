using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Produkt")]
        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Stan musi być większy niż 0!")]
        public int Amount { get; set; }

        public int ProductTypeId { get; set; }
        [ForeignKey("ProduktTypeId")]

        public virtual ProductType ProductType { get; set; }
    }
}