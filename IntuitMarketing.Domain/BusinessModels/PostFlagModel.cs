using System;

namespace IntuitMarketing.Domain.BusinessModels
{
    public class PostFlagModel
    {
        public Guid UserId { get; set; }
        public string Flag { get; set; }
        public bool Override { get; set; }
    }
}
