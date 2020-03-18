using IntuitMarketing.Domain.Enums;

namespace IntuitMarketing.Domain.HelpModels
{
    public class BusinessValidationResult
    {
        public bool IsSuccess { get; set; }
        public LeadStatus Status { get; set; }
    }
}
