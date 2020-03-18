using System;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class LeadStatusHistory
    {
        public Guid Id { get; set; }
        public Guid LeadId { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public string ServiceName { get; set; }
        public DateTime Date { get; set; }

        public virtual Leads Lead { get; set; }
        public virtual Users User { get; set; }
    }
}
