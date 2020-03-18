using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Reports
    {
        public Reports()
        {
            ReportColumns = new HashSet<ReportColumns>();
            ReportFilters = new HashSet<ReportFilters>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Query { get; set; }

        [JsonIgnore]
        public virtual ICollection<ReportColumns> ReportColumns { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReportFilters> ReportFilters { get; set; }
    }
}
