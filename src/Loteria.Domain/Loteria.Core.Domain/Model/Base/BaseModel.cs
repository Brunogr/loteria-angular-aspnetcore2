using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Core.Domain.Model.Base
{
    public class BaseModel
    {
        public BaseModel(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
