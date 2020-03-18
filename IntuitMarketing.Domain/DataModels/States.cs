using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class States
    {
        public States()
        {
            Counties = new HashSet<Counties>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Counties> Counties { get; set; }
    }
}
