using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshop.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        [Range(0.01,100.00,ErrorMessage ="Price must be between $0.01 and $100.00")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
