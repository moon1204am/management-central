using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementCentral.Shared.Domain
{
    public class Device
    {
        public int DeviceId { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Type { get; set; } = string.Empty;
        public  Status Status { get; set; }
    }
}
