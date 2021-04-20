using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.EfStuff.Model
{
    public class Order : BaseModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public double Period { get; set; }
    }
}
