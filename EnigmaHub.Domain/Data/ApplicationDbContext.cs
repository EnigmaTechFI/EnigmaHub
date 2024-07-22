
using EnigmaHub.Domain.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnigmaHub.Domain.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<MyUser> MyUsers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerMarketingData> CustomerMarketingDatas { get; set; }
    
    
    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
    #endregion
    
    #region OnSaveChanges
    public async Task<int> SaveChangesAsync(string userId)
    {
        this.ChangeTracker.DetectChanges();
        var added = this.ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Added)
            .Select(t => t.Entity)
            .ToArray();
        var now = DateTime.Now;
        foreach (var entity in added)
        {
            if (entity is ITrack)
            {
                var track = entity as ITrack;
                track.CreatedDate = now;
                track.LastModifiedDate = now;
                track.CreatedBy = userId;
                track.LastModifiedBy = userId;
            }
        }

        var modified = this.ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Modified)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in modified)
        {
            if (entity is ITrack)
            {
                var track = entity as ITrack;
                track.LastModifiedDate = now;
                track.LastModifiedBy = userId;
            }
        }
        return await base.SaveChangesAsync();
    }
    #endregion
}