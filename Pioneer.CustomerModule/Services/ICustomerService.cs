using Pioneer.CustomerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.CustomerModule.Services
{
   public interface ICustomerService
    {
        IQueryable<CustomerResponse> Get();
        CustomerResponse GetById(int id);
        CustomerResponse GetByUserName(string userName);
        int Create(CustomerCreate buyer);
        void Update(CustomerCreate buyer);
        void Delete(int id);
    }
}
