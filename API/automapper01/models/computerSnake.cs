namespace Computer.Models
{
    public class ComputerSnake
    {
        public int? computer_id { get; set; }
        public string? motherboard { get; set; }
        public int? cpu_cores { get; set; }
        public bool? has_wifi { get; set; }
        public bool? has_lte { get; set; }
        public DateTime? release_date { get; set; }
        public decimal? price { get; set; }
        public string? video_card { get; set; }

        public ComputerSnake()
        {
            if (price == null)
            {
                price = 0;
            }
            if (motherboard == null)
            {
                motherboard = "";
            }
            if (video_card == null)
            {
                video_card = "";
            }
        }

    }
}