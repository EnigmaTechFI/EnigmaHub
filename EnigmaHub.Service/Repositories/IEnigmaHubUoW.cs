using EnigmaHub.Domain.Context;
using EnigmaHub.Domain.Data;
using EnigmaHub.Service.Repositories.Base;

namespace EnigmaHub.Service.Repositories;

public interface IEnigmaHubUoW<T> where T : class 
{
    void Commit(MyUser user);
    void Rollback();
    Task CommitAsync(string userId);
    Task CommitAsync(MyUser user);
    Task RollbackAsync();
    public ApplicationDbContext DbContext { get; }
    IRepositoryBase<T> RepositoryBase { get; }
}