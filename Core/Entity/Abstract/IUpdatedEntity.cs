using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Abstract
{
    public interface IUpdatedEntity
    {
        int? UpdatedId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
