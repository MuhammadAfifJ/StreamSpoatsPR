
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Shared
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        [ForeignKey("Purchase")]
        public string ItemSerial { get; set; }
        public virtual Purchase Purchase { get; set; }
        [ForeignKey("Sport")]
        public int SportName { get; set; }
        public virtual Sport Sport { get; set; }
        [ForeignKey("Type")]
        public int ItemType { get; set; }
        public virtual Type Type { get; set; }
        [ForeignKey("Brand")]
        public int BrandName { get; set; }
        public virtual Brand Brand { get; set; }
    }


    public class Purchase
    {
        [Key]
        public string ItemSerial { get; set; }
        public DateTime? PurchaseDate { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }

    }


    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewDetails { get; set; }
        public string ReviewRating { get; set; }

        public DateTime? ReviewDateTime { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
    }

    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
