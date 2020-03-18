using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Sites
    {
        public int Id { get; set; }
        public int CampaingId { get; set; }
        public string Domain { get; set; }

        public virtual Campaigns Campaing { get; set; }
    }
}
