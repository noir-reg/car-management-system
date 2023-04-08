using PRN211PE_SP23_MaVanMeo.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211PE_SP23_MaVanMeo.Repository.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private CustomerAccountsContext _db;

        public CustomerRepo()
        {
            _db = new CustomerAccountsContext();
        }
        public List<Customer> GetAllCustomer()
        {
            return _db.Customers.ToList();
        }
    }
}
