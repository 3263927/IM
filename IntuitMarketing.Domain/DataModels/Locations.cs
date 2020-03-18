using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Locations
    {
        public Locations()
        {
            LocationWorkingHours = new HashSet<LocationWorkingHours>();
            ZipLocationMapping = new HashSet<ZipLocationMapping>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Emails { get; set; }
        public string Phones { get; set; }
        public int CampaignId { get; set; }

        public virtual ICollection<LocationWorkingHours> LocationWorkingHours { get; set; }
        public virtual ICollection<ZipLocationMapping> ZipLocationMapping { get; set; }
        public virtual Campaigns Campaing { get; set; }
    }
}
