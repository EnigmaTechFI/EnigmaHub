using EnigmaHub.Domain.Context;
using EnigmaHub.Service.Interface;
using EnigmaHub.Service.Repositories;

namespace EnigmaHub.Service.Implementation;

public class CustomerService : ICustomerService
{
    private readonly IEnigmaHubUoW<Customer> _uoWCustomer;
    private readonly IEnigmaHubUoW<CustomerMarketingData> _uoWCustomerMarketingData;

    public CustomerService(IEnigmaHubUoW<Customer> uoWCustomer, IEnigmaHubUoW<CustomerMarketingData> uoWCustomerMarketingData)
    {
        _uoWCustomer = uoWCustomer;
        _uoWCustomerMarketingData = uoWCustomerMarketingData;
    }

    public async Task<CustomerMarketingData> AddCustomerMarketingData(CustomerMarketingData entity, string userId)
    {
        var res = await _uoWCustomerMarketingData.RepositoryBase.Create(entity);
        await _uoWCustomerMarketingData.CommitAsync(userId);
        return res;
    }
}