using FinShark.Data;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            if (user == null) return null;
            return await _context.Portfolios
                .Where(x => x.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.StockId,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap
                }).ToListAsync();
        }

         public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<IEnumerable<object>?> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            var portfolios =  await _context.Portfolios.ToListAsync();

            var LinqJoin = users.
                Join(portfolios, u => u.Id, p => p.AppUserId, (user, portfolio) => new
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    StockId = portfolio.StockId,
                    PortfolioCount = user.Portfolios.Count(),
                }).ToList();

            return LinqJoin;
        }

        public async Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
        {
            var portfolioModel = await _context.Portfolios
                .FirstOrDefaultAsync(x=>x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol);
            if(portfolioModel == null)
            {
                return null;
            }
            _context.Portfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;
        }
    }
}
