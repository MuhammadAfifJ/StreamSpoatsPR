using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Shared
{
    public class Serial
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ItemSerial { get; set; }
    }
}
