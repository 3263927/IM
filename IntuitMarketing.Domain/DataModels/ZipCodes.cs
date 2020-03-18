using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class ZipCodes
    {
        public ZipCodes()
        {
            ZipLocationMapping = new HashSet<ZipLocationMapping>();
        }

        public int Id { get; set; }
        public string Zip { get; set; }
        public int CityId { get; set; }
        public int? DmaId { get; set; }

        public virtual City City { get; set; }
        public virtual Dmas Dma { get; set; }
        public virtual ICollection<ZipLocationMapping> ZipLocationMapping { get; set; }
    }
}
