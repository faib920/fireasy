using Fireasy.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fireasy.Data.Entity.Test.Model
{
    public class MyDbContext : EntityContext
    {
        public IRepository<Products> Products { get; set; }

        public IRepository<Categories> Categories { get; set; }

        public IRepository<Customers> Customers { get; set; }

        public IRepository<Orders> Orders { get; set; }

        public IRepository<OrderDetails> OrderDetails { get; set; }

        public EntityRepository<Dept> Depts { get; set; }
    }
}
