using FinShark.Extensions;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinShark.Controllers
{
    [Route("api/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;

        public PortfolioController(UserManager<AppUser> userManager, 
            IStockRepository stockRepo,
            IPortfolioRepository portfolioRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepo = portfolioRepo;
        }

        [HttpGet("userPortfolio")]
        //[Authorize]
        public async Task<IActionResult> GetPortfolios()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return NotFound("No user logged in");
            }
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }
        [HttpGet("allUsers")]
        //[Authorize]
        public async Task<IActionResult> GetPortfoliosAllUsers()
        {
            var portfolios = await _portfolioRepo.GetAllAsync();

            return Ok(portfolios);
        }
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreatePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetBySymbolAsync(symbol);
            if(stock == null)
            {
                return NotFound("Stock not found");
            }
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            if (userPortfolio.Any(x=>x.Symbol.ToLower() == symbol.ToLower())) 
            {
                return BadRequest("Connot add same stock to portfolio");
            }
            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };
            await _portfolioRepo.CreateAsync(portfolioModel);
            if(portfolioModel == null)
            {
                return StatusCode(500, "Could not create");
            }else
            {
                return Created();  
            }
        }
        [HttpPost("createForUser")]
        [Authorize]
        public async Task<IActionResult> CreatePortfolioForUser(string symbol, string username)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepo.GetBySymbolAsync(symbol);
            if (stock == null)
            {
                return NotFound("Stock not found");
            }
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            if (userPortfolio.Any(x => x.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Connot add same stock to portfolio");
            }
            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };
            await _portfolioRepo.CreateAsync(portfolioModel);
            if (portfolioModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created();
            }
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            var filteredStock =  userPortfolio.Where(x=>x.Symbol.ToLower() == symbol.ToLower()).ToList();
            if (filteredStock.Count() == 1)
            {
                await _portfolioRepo.DeletePortfolio(appUser, symbol);
            }else
            {
                return BadRequest("Stock not in your portfolio");
            }
            return Ok();
        }
    }
}
