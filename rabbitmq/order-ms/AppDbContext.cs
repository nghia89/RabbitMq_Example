using Microsoft.EntityFrameworkCore;
using order_ms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_ms
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //_accessor = this.GetService<IHttpContextAccessor>();
        }
        public DbSet<OrderModel> OrderModels { set; get; }
    }
}
