using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Counties
    {
        public Counties()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }

        public virtual States State { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}
