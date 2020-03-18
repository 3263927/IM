using IntuitMarketing.Domain.Enums;
using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Campaigns
    {
        public Campaigns()
        {
            Invoices = new HashSet<Invoices>();
            Pages = new HashSet<Pages>();
            SendingRules = new HashSet<SendingRules>();
            Sites = new HashSet<Sites>();
            Locations = new HashSet<Locations>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientId ClientType { get; set; }
        public string Title { get; set; }

        public virtual Clients Client { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Pages> Pages { get; set; }
        public virtual ICollection<SendingRules> SendingRules { get; set; }
        public virtual ICollection<Sites> Sites { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }

        public static explicit operator Campaigns(int v)
        {
            throw new NotImplementedException();
        }
    }
}
