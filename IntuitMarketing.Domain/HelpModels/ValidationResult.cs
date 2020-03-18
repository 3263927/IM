namespace IntuitMarketing.Domain.HelpModels
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
