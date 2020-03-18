using System;

namespace IntuitMarketing.Domain.BusinessModels
{
    public class NewLead
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public string Macros { get; set; }
        public string PageId { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
        public string SourceId { get; set; }
        public string TransactionId { get; set; }
        public string Ip { get; set; }
    }
}
