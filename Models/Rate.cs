namespace ExpenseTracker.Models
{

    public class ResponseDataRate
    {
        public string Code { get; set; }

        public decimal BuyingRate { get; set; }

        public decimal SellingRate { get; set; }
    }

    public class ResponseData
    {
        public List<ResponseDataRate> Data { get; set; }

        public string Error { get; set; }
    }
}
