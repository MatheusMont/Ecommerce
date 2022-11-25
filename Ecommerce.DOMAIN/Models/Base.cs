using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Models
{
    public class Base
    {
        private DateTime CreationDate { get; } = DateTime.Now;
        private DateTime DeletionDate { get; set; }
    }
}
