using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class DtoGetBase
    {
        // İsminin get olması sebebi get işlemleri için kullandığımız için.

        public virtual ResultStatus ResultStatus { get; set; } // sanal bir property olduğunu belirttik
        public virtual string Message { get; set; }
    }
}
