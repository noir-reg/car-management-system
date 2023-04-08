
using PRN211PE_SP23_MaVanMeo.Repository.Models;

namespace PRN211PE_SP23_MaVanMeo.Repository.Repository;

public interface IAccountRepository
{
    IEnumerable<CustomerAccount> GetAllAccounts();
    CustomerAccount GetAccountById(string id);
    IEnumerable<CustomerAccount> GetAccountByReligon(string region);   
    void Delete(string id);

}
