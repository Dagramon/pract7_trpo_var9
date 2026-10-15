using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract7.Model
{
    public partial class Device
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Manufacturer { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public bool? IsActive { get; set; }
    }
}
