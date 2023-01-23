using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Product Price")]
        [Range(0.0,10000.0, ErrorMessage ="Price should be between 0 and 10000")]
        public double Price { get; set; }

        //public int PackSize { get; set; }

        [Required]
        [Range(0, int.MaxValue , ErrorMessage ="Quantity should be greater than zero")]
        public int Quantity { get; set; }

        [Required]
        public int Discount { get; set; }

        [Required]
        public int TotalPrice { get; set; }
        
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public PackSize PackSize { get; set; }

        public int PackSizeId { get; set; }

        //public List<Product> GetProducts()
        //{
        //    return new List<Product>
        //    {
        //        new Product{Id=101, Name="Apple", Price=120, Quantity=1, Discount=10, TotalPrice=108},
        //        new Product{Id=101, Name="Onion", Price=50, Quantity=1, Discount=4, TotalPrice=48},
        //        new Product{Id=101, Name="Banana", Price=40, Quantity=1, Discount=5, TotalPrice=38},
        //        new Product{Id=101, Name="Orange", Price=80, Quantity=1, Discount=4, TotalPrice=76},
        //        new Product{Id=101, Name="Cherry", Price=200, Quantity=1, Discount=10, TotalPrice=180},
        //        new Product{Id=101, Name="Tamota", Price=20, Quantity=1, Discount=2, TotalPrice=19},
        //        new Product{Id=101, Name="Carrot", Price=160, Quantity=1, Discount=8, TotalPrice=130},
        //    };
        //}
    }
}