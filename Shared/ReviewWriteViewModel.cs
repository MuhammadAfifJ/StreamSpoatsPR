using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Shared
{
    public class ReviewWriteViewModel
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public string ReviewDetails { get; set; }
        public string ReviewRating { get; set; }
        [Required]

        public DateTime? ReviewDateTime { get; set; }
        public int UserId { get; set; }
        //[Required]
        public string ItemSerial { get; set; }
        //[Required]
        public string ProductName { get; set; }
        public int SportName { get; set; }
        public int ItemType { get; set; }
        public int BrandName { get; set; }
    }
}