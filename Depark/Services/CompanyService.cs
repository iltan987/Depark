using Depark.Contexts;
using Depark.Contracts.Services;
using Depark.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Depark.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyDBContext context;

        public CompanyService(CompanyDBContext context)
        {
            this.context = context;
        }

        async Task ICompanyService.CreateAsync(Company company)
        {
            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();
        }

        async Task ICompanyService.UpdateAsync(Company company)
        {
            context.Entry(company).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        async Task ICompanyService.DeleteAsync(int id)
        {
            var company = await context.Companies.FindAsync(id);
            if (company != null)
            {
                context.Companies.Remove(company);
                await context.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Company>> ICompanyService.GetAllAsync()
        {
            return await context.Companies.ToListAsync();
        }
    }
}