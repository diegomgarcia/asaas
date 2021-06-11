using System;
using System.Threading.Tasks;
using AsaaS.Common;
using AsaaS.Entities;

namespace AsaaS.Contracts
{
    public interface IRepositoryService<T> where T: class
    {
        string ServiceUrl();
        Task<T> CreateAsync(T model);
        Task<T> ReadAsync(string id);
        Task<T> UpdateAsync(T model);
        Task<Boolean> DeleteAsync(string id);
    }


    public interface ICustomerService : IRepositoryService<Customer>
    {
        //TODO: Implement ListAll
    }
    
    public interface ISubscriptionService : IRepositoryService<Subscription>
    {
        Task<ResultSet<Payment>> ReadPayments(string subscriptionId);
    }
}