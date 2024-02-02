using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);
        Task<IEnumerable<object>?> GetAllAsync();
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio> DeletePortfolio(AppUser user, string symbol);
    }
}
