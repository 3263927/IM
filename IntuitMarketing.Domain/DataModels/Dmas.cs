using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Dmas
    {
        public Dmas()
        {
            ZipCodes = new HashSet<ZipCodes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ZipCodes> ZipCodes { get; set; }
    }
}
