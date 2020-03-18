using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class LocationWorkingHours
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string WorkingHours { get; set; }
        public string AppHours { get; set; }

        public virtual Locations Location { get; set; }
    }
}
