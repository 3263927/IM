using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class AccountLeads
    {
        public Guid Id { get; set; }
        public int? InvoiceId { get; set; }

        public virtual Invoices Invoice { get; set; }
    }
}
