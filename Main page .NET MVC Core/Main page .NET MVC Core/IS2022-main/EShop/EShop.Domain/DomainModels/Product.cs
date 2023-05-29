using EShop.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShop.Domain.DomainModels
{
    public class Product : BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string ProductImage { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double ProductPrice { get; set; }
        [Required]
        [Display(Name = "Rating")]
        public double ProductRating { get; set; }

      


        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }

    }
}
