namespace IntuitMarketing.Domain.HelpModels
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
