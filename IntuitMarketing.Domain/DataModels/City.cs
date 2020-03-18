using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class City
    {
        public City()
        {
            ZipCodes = new HashSet<ZipCodes>();
        }

        public int Id { get; set; }
        public int CountyId { get; set; }
        public string Name { get; set; }

        public virtual Counties County { get; set; }
        public virtual ICollection<ZipCodes> ZipCodes { get; set; }
    }
}
