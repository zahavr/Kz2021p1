using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model;

namespace WebApplication1.Models
{
    public class ScheduleViewModel
    {
        public virtual List<dayOfWeek> days { get; set; }
        public int count { get; set; }
    }
}
