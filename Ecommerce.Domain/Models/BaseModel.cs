using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; } = DateTime.UtcNow.AddHours(-3);
    }
}
