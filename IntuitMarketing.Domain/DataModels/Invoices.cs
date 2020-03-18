using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Invoices
    {
        public Invoices()
        {
            AccountLeads = new HashSet<AccountLeads>();
        }

        public int Id { get; set; }
        public int CampaingId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }

        public virtual Campaigns Campaing { get; set; }
        public virtual ICollection<AccountLeads> AccountLeads { get; set; }
    }
}
