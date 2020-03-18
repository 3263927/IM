using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.DataModels
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            LeadStatusHistory = new HashSet<LeadStatusHistory>();
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Permisions { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<LeadStatusHistory> LeadStatusHistory { get; set; }
    }
}
