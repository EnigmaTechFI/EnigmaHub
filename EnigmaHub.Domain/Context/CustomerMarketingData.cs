namespace EnigmaHub.Domain.Context;

public class CustomerMarketingData
{
    public Guid Id { get; set; }
    
    public Customer Customer { get; set; }
    public Guid? CustomerId { get; set; }
    
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    
    
}