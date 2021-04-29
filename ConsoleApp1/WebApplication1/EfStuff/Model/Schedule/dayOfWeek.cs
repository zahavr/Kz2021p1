using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.EfStuff.Model
{
    public class dayOfWeek : BaseModel
    {
        public string name { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual Hall hall { get; set; }
        //public virtual List<TimeRanges> timeRanges { get; set; } 
    }
}
