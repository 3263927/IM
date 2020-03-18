using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Pages
    {
        public Pages()
        {
            InvalidSubmissions = new HashSet<InvalidSubmissions>();
            Leads = new HashSet<Leads>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Clicks { get; set; }
        public string ActiveDates { get; set; }
        public int CampaingId { get; set; }

        public virtual Campaigns Campaing { get; set; }
        public virtual ICollection<InvalidSubmissions> InvalidSubmissions { get; set; }
        public virtual ICollection<Leads> Leads { get; set; }
    }
}
