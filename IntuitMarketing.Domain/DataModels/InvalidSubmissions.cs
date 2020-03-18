using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class InvalidSubmissions
    {
        public Guid Id { get; set; }
        public Guid PageId { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public string Ip { get; set; }
        public DateTime Date { get; set; }

        public virtual Pages Page { get; set; }
    }
}
