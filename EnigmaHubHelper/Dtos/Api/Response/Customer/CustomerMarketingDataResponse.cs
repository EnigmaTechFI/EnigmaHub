using System.Text.Json.Serialization;
using EnigmaHub.Domain.Constants;
using EnigmaHub.Domain.Context;
using EnigmaHub.Domain.Dto;
using EnigmaHubHelper.Dtos.Api.Request.Customer;

namespace EnigmaHubHelper.Dtos.Api.Response;

public class CustomerMarketingDataResponse : ResultDto
{
    public CustomerMarketingDataResponse(bool success, string message, Error.CustomError desc, string type) : base(success, message, desc, type)
    {
    }

    public CustomerMarketingDataResponse(bool success) : base(success)
    {
    }
    
    public CustomerMarketingDataResponse(bool success, ErrorDto error) : base(success)
    {
        this.Success = success;
        this.Error = error;
    }
    
    [JsonPropertyName("data")]
    public CustomerMarketingDataDto? Data { get; set; }

}