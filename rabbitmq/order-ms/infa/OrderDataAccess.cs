using Microsoft.EntityFrameworkCore;
using order_ms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order_ms.infa
{
    public class OrderDataAccess : IOrderDataAccess
    {
        private readonly AppDbContext _appContext;
        public OrderDataAccess(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task Add(OrderModel model)
        {
            _appContext.Add(model);
            await _appContext.SaveChangesAsync();
        }

        public async Task<List<OrderModel>> GetAll()
        {
            return await _appContext.OrderModels.ToListAsync();
        }
    }
}

