using EnigmaHub.Domain.Constants;
using EnigmaHub.Domain.Context;
using EnigmaHub.Domain.Dto;
using EnigmaHub.Service.Interface;
using EnigmaHub.Validator;
using EnigmaHubHelper.Dtos.Api.Request.Customer;
using EnigmaHubHelper.Dtos.Api.Response;

namespace EnigmaHubHelper.Helper;

public class CustomerHelper
{
    private readonly ICustomerService _customerService;
    private readonly CustomerMarketingDataValidator _customerMarketingDataValidator;

    public CustomerHelper(ICustomerService customerService, CustomerMarketingDataValidator customerMarketingDataValidator)
    {
        _customerService = customerService;
        _customerMarketingDataValidator = customerMarketingDataValidator;
    }

    public async Task<CustomerMarketingDataResponse> AddCustomerMarketingData(CustomerMarketingDataRequest request, MyUser user)
    {
        var entity = new CustomerMarketingData
        {
            Email = request.Email,
            Phone = request.Phone?.Replace(" ", ""),
            Name = request.Name,
            Surname = request.Surname
        };

        var validation = await _customerMarketingDataValidator.Validator(entity);
        if (!validation.Success)
        {
            return new CustomerMarketingDataResponse(false, validation.Error);
        }

        if (_customerService.EmailExist(entity.Email))
            return new CustomerMarketingDataResponse(false, new ErrorDto("L'email inserita è già stata utilizzata.", Error.CustomError.GENERAL, Error.EMAIL_ERROR));
        
        if (_customerService.PhoneExist(entity.Phone))
            return new CustomerMarketingDataResponse(false, new ErrorDto("Il numero di telefono inserito è già stato utilizzato.", Error.CustomError.GENERAL, Error.PHONE_ERROR));

        var res = await _customerService.AddCustomerMarketingData(entity, user.Id);
        request.Id = res.Id;
        
        return new CustomerMarketingDataResponse(true)
        {
            Data = request
        };
    }
    public async Task<ResultDto> AddCustomerMarketingData(string email, string phone, MyUser user)
    {
        var entity = new CustomerMarketingData
        {
            Email = email,
            Phone = phone?.Replace(" ", ""),
        };

        var validation = await _customerMarketingDataValidator.Validator(entity);
        if (!validation.Success)
        {
            return validation;
        }

        if (_customerService.EmailExist(entity.Email))
            return new ResultDto(false, "L'email inserita è già stata utilizzata.", Error.CustomError.GENERAL, Error.EMAIL_ERROR);
        
        if (_customerService.PhoneExist(entity.Phone))
            return new ResultDto(false, "Il numero di telefono inserito è già stato utilizzato.", Error.CustomError.GENERAL, Error.PHONE_ERROR);

        var res = await _customerService.AddCustomerMarketingData(entity, user.Id);
        entity.Id = res.Id;

        return new ResultDto(true);
    }
}