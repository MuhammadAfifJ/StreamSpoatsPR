using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Shared
{
    public class Type
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ItemType { get; set; }
        [Required]
        public string ItemSize { get; set; }
        [Required]
        public string ItemColor { get; set; }
    }
}
