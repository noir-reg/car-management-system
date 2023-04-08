

using Microsoft.EntityFrameworkCore;
using PRN211PE_SP23_MaVanMeo.Repository.Models;

namespace PRN211PE_SP23_MaVanMeo.Repository.Repository;

public class AccountRepository : IAccountRepository
{
    private CustomerAccountsContext _db;

    public AccountRepository()
    {
        _db = new CustomerAccountsContext();
    }

     

    public void Delete(string id)
    {
      var a= GetAccountById(id);
        _db.CustomerAccounts.Remove(a);
        _db.SaveChanges();
    }
    public  CustomerAccount  GetAccountById(string id)
    => _db.CustomerAccounts.Include(a => a.Customer).Where(a=>a.AccountId.Equals(id)).FirstOrDefault();
    public IEnumerable<CustomerAccount> GetAccountByReligon(string region)
    => _db.CustomerAccounts.Include(a => a.Customer).Where(a => a.RegionName.Contains(region));
    public IEnumerable<CustomerAccount> GetAllAccounts()
        => _db.CustomerAccounts.Include(a=>a.Customer);   
    

     

    
}
