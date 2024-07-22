using EnigmaHub.Domain.Context;

namespace EnigmaHub.Service.Interface;

public interface ICustomerService
{
    public Task<CustomerMarketingData> AddCustomerMarketingData(CustomerMarketingData entity, string userId);
    bool EmailExist(string? entityEmail);
    bool PhoneExist(string? entityPhone);
}