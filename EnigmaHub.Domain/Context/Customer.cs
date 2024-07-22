namespace EnigmaHub.Domain.Context;

public class Customer : TrackableEntity
{
    public Guid Id { get; set; }
    public string? BusinessName { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string EAN { get; set; }
    public string Type => !string.IsNullOrEmpty(EAN) ? "Società" : "Privato";
    public string FullAddress => Address + ", " + StreetNumber + ", " + City;

    public string? FiscalCode { get; set; }
    public string? NationCode { get; set; }
    public string? Nation { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? Province { get; set; }
    public string? ProvinceCode { get; set; }
    public string? City { get; set; }
    public string? Note { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Pec { get; set; }
    public string? StreetNumber { get; set; }
    public string? SDI { get; set; }
    public virtual List<CustomerMarketingData> CustomerMarketingDatas { get; set; }
}