using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Abstract
{
    public interface ICreatedEntity
    {
        int CreatedId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
