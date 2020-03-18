using IntuitMarketing.Domain.Enums;
using System;

namespace IntuitMarketing.Domain.BusinessModels
{
    public class LeadStatusModel
    {
        public Guid LeadId { get; set; }
        public Guid UserId { get; set; }
        public LeadStatus Status { get; set; }
        public DateTime Date { get; set; }
        public string ServiceName { get; set; }
    }
}
