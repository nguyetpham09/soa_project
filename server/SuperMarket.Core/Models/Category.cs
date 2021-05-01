using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Core.Models
{
    [Table("Category")]
    public class Category
    {
        public Category(){
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set;}
    }
}