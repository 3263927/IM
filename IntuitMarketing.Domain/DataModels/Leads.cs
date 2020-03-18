using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Leads
    {
        public Leads()
        {
            Comments = new HashSet<Comments>();
            LeadStatusHistory = new HashSet<LeadStatusHistory>();
        }

        public Guid Id { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("rest_name")]
        public string RestName { get; set; }
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
        [Column("source_id")]
        public string SourceId { get; set; }
        [Column("page_id")]
        public Guid PageId { get; set; }
        public string Ip { get; set; }
        [Column("transaction_id")]
        public string TransactionId { get; set; }
        public string Data { get; set; }
        public string Macros { get; set; }
        [Column("project_lead_id")]
        public int ProjectLeadId { get; set; }

        [JsonIgnore]
        public virtual Pages Page { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comments> Comments { get; set; }
        [JsonIgnore]
        public virtual ICollection<LeadStatusHistory> LeadStatusHistory { get; set; }
    }
}
