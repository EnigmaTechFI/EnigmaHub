using EliteDomus.Domain.Context;
using EliteDomus.Domain.Data;
using EnigmaHub.Service.Repositories.Base;

namespace EliteDomus.Service.Repositories;

public interface IEnigmaHubUoW<T> where T : class 
{
    void Commit(MyUser user);
    void Rollback();
    Task CommitAsync(string userId);
    Task CommitAsync(MyUser user);
    Task RollbackAsync();
    public ApplicationDbContext DbContext { get; }
    IMyUserRepository MyUserRepository { get; }
    IRepositoryBase<T> RepositoryBase { get; }
}