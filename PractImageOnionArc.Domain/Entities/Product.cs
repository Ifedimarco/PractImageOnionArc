using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PractImageOnionArc.Domain.Entities
{
   public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductsName { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductsModel { get; set; }
        [Required]
        public int ProductsPrice { get; set; }
        [StringLength(50)]
        public string ProductsImage { get; set; }
        [NotMapped]
        [Display(Name ="Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
