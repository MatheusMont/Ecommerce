using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Models
{
    public class Base
    {
        public Guid Id { get; protected set; }
        protected DateTime CreationDate { get; } = DateTime.Now;
        protected DateTime DeletionDate { get; set; }
        protected DateTime UpdateDate { get; set; }
    }
}
