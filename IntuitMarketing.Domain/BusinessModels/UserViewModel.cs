using System;
using System.Collections.Generic;
using System.Text;

namespace IntuitMarketing.Domain.BusinessModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
    }
}
