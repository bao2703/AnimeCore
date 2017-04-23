using System.Collections.Generic;
using System.Security.Claims;
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
        Task<TEntity> FindByNameAsync(string entityName);
        List<TEntity> ToList();
        Task<IdentityResult> AddClaimAsync(TEntity entity, Claim claim);
        Task<IList<Claim>> GetClaimsAsync(TEntity entity);
    }
}