using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Shared
{
    public class Sport
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string SportName { get; set; }
    }
}
