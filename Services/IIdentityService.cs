using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Services
{
    public interface IIdentityService<TEntity> where TEntity : class
    {
        Task<IdentityResult> CreateAsync(TEntity entity);
        Task<IdentityResult> UpdateAsync(TEntity entity);
        Task<IdentityResult> DeleteAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(string id);
        List<TEntity> ToList();
    }
}