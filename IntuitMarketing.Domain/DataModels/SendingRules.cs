namespace IntuitMarketing.Domain.DataModels
{
    public partial class SendingRules
    {
        public int Id { get; set; }
        public int CampaingId { get; set; }
        public int Type { get; set; }
        public string Selector { get; set; }
        public string Body { get; set; }
        public string Parameters { get; set; }
        public string Descriptor { get; set; }

        public virtual Campaigns Campaing { get; set; }
    }
}
