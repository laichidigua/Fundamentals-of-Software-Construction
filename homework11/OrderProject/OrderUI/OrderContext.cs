using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
namespace OrderUI
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class OrderContext:DbContext
    {
        public OrderContext() : base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }
        public DbSet<Goods> DbGoods { set; get; }
        public DbSet<OrderDetails> DbOrderDetails { set; get; }
        public DbSet<Order> DbOrders { set; get; }
        public DbSet<Client> DbClients { set; get; }
    }
}
