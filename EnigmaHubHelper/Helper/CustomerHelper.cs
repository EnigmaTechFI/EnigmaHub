using EnigmaHub.Domain.Context;
using EnigmaHub.Service.Interface;
using EnigmaHubHelper.Dtos.Api.Request.Customer;
using EnigmaHubHelper.Dtos.Api.Response;

namespace EnigmaHubHelper.Helper;

public class CustomerHelper
{
    private readonly ICustomerService _customerService;

    public CustomerHelper(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<CustomerMarketingDataResponse> AddCustomerMarketingData(CustomerMarketingDataRequest request, MyUser user)
    {
        var entity = new CustomerMarketingData
        {
            Email = request.Email,
            Phone = request.Phone,
            Name = request.Name,
            Surname = request.Surname
        };

        var res = await _customerService.AddCustomerMarketingData(entity, user.Id);
        request.Id = res.Id;
        
        return new CustomerMarketingDataResponse(true)
        {
            Data = request
        };
    }
}