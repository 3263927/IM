using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Countries
    {
        public Countries()
        {
            States = new HashSet<States>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<States> States { get; set; }
    }
}
