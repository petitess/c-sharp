using FinShark.Data;
using FinShark.Dtos.Stock;
using FinShark.Extensions;
using FinShark.Helpers;
using FinShark.Interfaces;
using FinShark.Mappers;
using FinShark.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace FinShark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;
        private readonly UserManager<AppUser> _userManager;

        public StockController(ApplicationDbContext context, 
            IStockRepository stockRepository,
            UserManager<AppUser> userManager) 
        {
            //_context = context;
            _stockRepository = stockRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllU()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /*var username = User.GetUsername();
            if (username == null)
            {
                return BadRequest("User not logged in");
            }*/

            var stocks = await _stockRepository.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();
            return Ok(stockDto);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAll(string search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /*var username = User.GetUsername();
            if (username == null)
            {
                return BadRequest("User not logged in");
            }*/

            var stocks = await _stockRepository.SearchAsync(search);
            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();
            return Ok(stockDto);
        }

        [HttpGet("userStocks")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var stocks = await _stockRepository.GetAllAsync();

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return NotFound("No user logged in");
            }
            var stocks = await _stockRepository.GetAllForUserAsync(appUser.Id);

            var stockDto = stocks.ToList();
            return Ok(stockDto);
        }

        [HttpGet("tiny")]
        public async Task<IActionResult> GetAll2(bool OrderByDesc = true)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepository.GetAllTinyAsync(OrderByDesc);

            var stockDto = stocks.Select(s => s.ToStockTinyDto()).ToList();
            return Ok(stockDto);
        }

        [HttpGet("filtered")]
        public async Task<IActionResult> GetAllFiltered([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepository.GetAllFilteredAsync(query);

            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();
            return Ok(stockDto);
        }
        //[Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id = 1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpGet("tiny/{id:int}")]
        public async Task<IActionResult> GetByIdTiny([FromRoute] int id = 1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            var stockDto = stock.ToStockTinyDto();
            return Ok(stockDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto ) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockRepository.UpdateAsync(id, updateDto);
            if(stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockRepository.DeleteAsync(id);

            if(stockModel == null) 
            {
                return NotFound();
            }
            
            return Ok(stockModel.CompanyName + " removed successfully"); //NoContent();
        }
    }
}
