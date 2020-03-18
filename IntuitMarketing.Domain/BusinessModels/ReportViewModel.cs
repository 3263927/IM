using System;
using System.Collections.Generic;
using System.Dynamic;
using IntuitMarketing.Domain.DataModels;

namespace IntuitMarketing.Domain.BusinessModels
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ExpandoObject> Data { get; set; }
        public IEnumerable<ReportFilters> Filters { get; set; }
        public IEnumerable<ReportColumns> Columns { get; set; }
    }
}