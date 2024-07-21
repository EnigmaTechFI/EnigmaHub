using System.Text.Json.Serialization;

namespace EnigmaHubHelper.Dtos.Api.Request.Customer;

public class CustomerMarketingDataDto
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("surname")]
    public string? Surname { get; set; }
}