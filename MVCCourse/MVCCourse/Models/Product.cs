using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCourse.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name ="Description")]
        [Required(ErrorMessage = "Field Description is required")]
        public string Desctiption { get; set; }
        [Range(1, 10, ErrorMessage ="This value is not valid. Min=1; Max=10")]
        public int Amount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
