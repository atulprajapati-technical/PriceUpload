namespace PriceUploadAPI.Entities
{
    public class PriceUpload
    {
        public int Id { get; set; }
        public string Mit { get; set; }
        public string Code { get; set; }
        public string CurrencyCode { get; set; }
        public long Subscription { get; set; }
        public long Redemption { get; set; }
        public long Expense { get; set; }
        public long Net { get; set; }
    }
}
