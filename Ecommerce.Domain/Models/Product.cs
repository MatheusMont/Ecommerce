using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public class Product : BaseModel
    {
        public String Name { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
        public double Price { get; set; }
        public String Description { get; set; }
        public virtual User User { get; set; }
    }
}
