using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.EfStuff.Model
{
    public class Schedule: BaseModel
    { 
        public virtual List<dayOfWeek> days { get; set; }
        public int count { get; set; }
      //  SportComplex id { get; set; }
    }
}
