using EliteDomus.Service.Repositories;
using EnigmaHub.Domain.Context;
using EnigmaHub.Domain.Data;
using EnigmaHub.Service.Repositories.Base;

namespace EnigmaHub.Service.Repositories;

public class EliteDomusUoW<T> : IEliteDomusUoW<T> where T : class
{
 
    private readonly ApplicationDbContext _dbContext;

    public EliteDomusUoW(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        DbContext = dbContext;
    }
    
    public void Commit(MyUser user) => this._dbContext.SaveChanges();
    public async Task CommitAsync(MyUser user)
    {
        await _dbContext.SaveChangesAsync(user.Id);
    }
    public async Task CommitAsync(string userId)
    {
        await _dbContext.SaveChangesAsync(userId);
    }
    public void Rollback() => _dbContext.Dispose();
    public async Task RollbackAsync() => await _dbContext.DisposeAsync();
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    
    public ApplicationDbContext DbContext { get; }

    private IRepositoryBase<T> _repositoryBase;
    public IRepositoryBase<T> RepositoryBase => _repositoryBase ??= new RepositoryBase<T>(_dbContext);
    
}