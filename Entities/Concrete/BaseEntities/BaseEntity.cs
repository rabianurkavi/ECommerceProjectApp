using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.BaseEntities
{
    public class BaseEntity : IEntity
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
