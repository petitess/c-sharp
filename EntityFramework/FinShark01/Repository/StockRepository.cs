﻿using FinShark.Data;
using FinShark.Dtos.Stock;
using FinShark.Helpers;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            var commentModel = _context.Comments.Where(x => x.StockId == id);
            foreach (var comment in commentModel)
            {
                _context.Comments.Remove(comment);
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks
                .Include(c => c.Comments)
                .ThenInclude(x => x.AppUser)
                .ToListAsync();
        }

        public async Task<IEnumerable<object>?> GetAllForUserAsync(string userId)
        {
            var portfolios = await _context.Portfolios.ToListAsync();
            var stocks = await _context.Stocks.ToListAsync();

            var userPortfolio = stocks.
                Join(portfolios, s => s.Id, p => p.StockId, (stock, portfolio) => new
                {
                    StockId = stock.Id,
                    CompanyName = stock.CompanyName,
                    Symbol = stock.Symbol,
                    UserId = portfolio.AppUserId,
                    PortfolioCount = stock.Portfolios.Count(),
                }).Where(x=>x.UserId == userId);


            return userPortfolio;
        }

        public async Task<List<Stock>> GetAllTinyAsync(bool OrderByDesc)
        {

            if (!OrderByDesc) 
            return await _context.Stocks.ToListAsync();
            else
            return await _context.Stocks.OrderByDescending(x=>x.Id).ToListAsync();
        }

        public async Task<List<Stock>> SearchAsync(string search)
        {
            return await _context.Stocks
                .Where(x => x.CompanyName.Contains(search) || x.Symbol.Contains(search) || x.Industry.Contains(search))
                .ToListAsync();
        }

        public async Task<List<Stock>> GetAllFilteredAsync(QueryObject query)
        {
            var stock = _context.Stocks.Include(c => c.Comments).ThenInclude(x=>x.AppUser).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stock = stock.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stock = stock.Where(s => s.Symbol.Contains(query.Symbol));  
            }
            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stock = query.IsDecsending ? stock.OrderByDescending(s => s.Symbol) : stock.OrderBy(s=> s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stock.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            //return await _context.Stocks.FindAsync(id);
            return await _context.Stocks.Include(c => c.Comments).Include(x=>x.Portfolios).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> GetByIdTinyAsync(int id)
        {
            //return await _context.Stocks.FindAsync(id);
            return await _context.Stocks.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> GetByIdUserAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Symbol == symbol);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(x => x.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.MarketCap = stockDto.MarketCap;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;

            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}
