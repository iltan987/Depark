using Depark.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Depark.Contracts.Services
{
    public interface ICompanyService
    {
        Task CreateAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(int id);
        Task<IEnumerable<Company>> GetAllAsync();
    }
}