namespace EnigmaHub.Domain.Context;

public abstract class TrackableEntity : ITrack
{
    
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    
    public string? AdditionalInfo { get; set; }
    
    public string? ChangeDescription { get; set; }
    
}

public interface ITrack
{
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    
    public string? AdditionalInfo { get; set; }
    
    public string? ChangeDescription { get; set; }
}