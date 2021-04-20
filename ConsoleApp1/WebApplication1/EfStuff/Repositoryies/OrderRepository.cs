using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model;

namespace WebApplication1.EfStuff.Repositoryies
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(KzDbContext kzDbContext) : base(kzDbContext) { }

        public Order GetByName(string name)
        {
            return _kzDbContext.Orders.SingleOrDefault(x => x.Name == name);
        }
    }
}
