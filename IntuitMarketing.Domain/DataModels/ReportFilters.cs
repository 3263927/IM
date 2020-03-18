using System;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class ReportFilters
    {
        public int Id { get; set; }
        public Guid ReportId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Values { get; set; }

        public virtual Reports Report { get; set; }
    }
}
