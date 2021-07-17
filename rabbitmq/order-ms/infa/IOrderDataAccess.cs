using order_ms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_ms.infa
{
   public interface IOrderDataAccess
    {
        public Task Add(OrderModel model);
        public Task<List<OrderModel>> GetAll();

    }
}
