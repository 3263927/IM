using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Comments
    {
        public Guid Id { get; set; }
        public Guid LeadId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public DateTime Date { get; set; }

        public virtual Leads Lead { get; set; }
        public virtual Users User { get; set; }
    }
}
