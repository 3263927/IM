using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Clients
    {
        public Clients()
        {
            Campaings = new HashSet<Campaigns>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Campaigns> Campaings { get; set; }
    }
}
