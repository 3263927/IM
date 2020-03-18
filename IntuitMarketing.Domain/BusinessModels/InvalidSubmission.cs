namespace IntuitMarketing.Domain.BusinessModels
{
    public class InvalidSubmission
    {
        public string Ip { get; set; }
        public string PageId { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
