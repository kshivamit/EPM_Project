using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Core.Base
{
    //Common property
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
