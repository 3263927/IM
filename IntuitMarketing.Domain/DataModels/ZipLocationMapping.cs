using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class ZipLocationMapping
    {
        public int Id { get; set; }
        public int ZipId { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ZipCodes Zip { get; set; }
    }
}
