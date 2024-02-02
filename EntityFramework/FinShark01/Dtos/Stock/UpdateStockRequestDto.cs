using System.ComponentModel.DataAnnotations;

namespace FinShark.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Company name must be 5 chracters")]
        [MaxLength(100, ErrorMessage = "Company name cannot be over 100 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.01, 1000)]
        public decimal LastDiv { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Industry name must be 5 chracters")]
        [MaxLength(20, ErrorMessage = "Industry name cannot be over 20 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 9000000000)]
        public long MarketCap { get; set; }
    }
}
