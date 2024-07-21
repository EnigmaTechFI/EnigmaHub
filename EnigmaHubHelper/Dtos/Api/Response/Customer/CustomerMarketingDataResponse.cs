using System.Text.Json.Serialization;
using EnigmaHub.Domain.Constants;
using EnigmaHub.Domain.Context;
using EnigmaHub.Domain.Dto;
using EnigmaHubHelper.Dtos.Api.Request.Customer;

namespace EnigmaHubHelper.Dtos.Api.Response;

public class AddCustomerMarketingDataResponse : ResultDto
{
    public AddCustomerMarketingDataResponse(bool success, string message, EnigmaError.CustomError desc, string type) : base(success, message, desc, type)
    {
    }

    public AddCustomerMarketingDataResponse(bool success) : base(success)
    {
    }
    
    [JsonPropertyName("data")]
    public CustomerMarketingDataRequest? Data { get; set; }

}