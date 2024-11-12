using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity
    {
        public int? UpdatedId { get; set; }
        public DateTime? UpdatedDate {  get; set; }
        public int CreatedId { get; set; }
        public DateTime CreatedDate {  get; set; }
    }
}
