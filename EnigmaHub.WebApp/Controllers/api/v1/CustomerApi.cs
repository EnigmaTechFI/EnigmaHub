using EnigmaHub.Domain.Constants;
using EnigmaHub.Domain.Dto;
using EnigmaHub.WebApp.CustomDataAttribute;
using EnigmaHubHelper.Dtos.Api.Request.Customer;
using EnigmaHubHelper.Dtos.Api.Response;
using EnigmaHubHelper.Helper;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace EnigmaHub.WebApp.Controllers.api.v1;

[ApiController]
public class CustomerApi : Controller
{
    private readonly CustomerHelper _customerHelper;
    
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public CustomerApi(CustomerHelper customerHelper)
    {
        _customerHelper = customerHelper;
    }

    [HttpPost("api/v1/customer/marketing-data")]
    public async Task<IActionResult> AddCustomerMarketingData([FromBody] CustomerMarketingDataRequest request)
    {
        try
        {
            var response = await _customerHelper.AddCustomerMarketingData(request, Constants.DevUser);
            return new JsonResult(response);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error executing api/v1/customer/marketing-data.");
            var response = new CustomerMarketingDataResponse(false, "Errore nella processazione della richiesta.", Error.CustomError.GENERAL, Error.API_ERROR);
            return new JsonResult(response);
        }
    }

    [HttpGet("api/v1/customer/marketing-data/{email}/{phone}")]
    public async Task<IActionResult> AddCustomerMarketingData(string email, string phone)
    {
        try
        {
            await _customerHelper.AddCustomerMarketingData(email, phone, Constants.DevUser);
            return Ok();
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error executing api/v1/customer/marketing-data.");
            return BadRequest();
        }
    }
}