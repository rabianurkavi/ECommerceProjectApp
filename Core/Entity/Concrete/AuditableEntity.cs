using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Concrete
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity
    {
        public int? UpdatedId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
