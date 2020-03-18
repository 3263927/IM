using System;
using System.Collections.Generic;

namespace IntuitMarketing.Domain.HelpModels
{
    public static class StaticServerSettings
    {
        public static string ConnectionString { get; set; }
        public static Guid ProgramUserId { get; set; }
        public static class Jwt
        {
            public static byte[] Secret { get; set; }
            public static int ExpirationDays { get; set; }
        }
        public static class Mailchimp
        {
            public static string Instance { get; set; }
            public static string ApiKey { get; set; }
            public static Dictionary<string, string> Lists { get; set; }
        }
        public static class GCP
        {
            public static string ProjectName { get; set; }

            public static class PubSub
            {
                public static string NewLeadTopicName { get; set; }
                public static string ValidatedLeadTopicName { get; set; }
                public static string NotValidatedLeadTopicName { get; set; }
                public static string SendMailTopicName { get; set; }
                public static string BusinessValidationLeadTopicName { get; set; }
                public static string MSLeadTopicName { get; set; }
                public static string CHSPLeadTopicName { get; set; }
                public static string FormattedLeadTopicName { get; set; }
                public static string ChangePhoneTopicName { get; set; }
                public static string SendLeadReportTopicName { get; set; }
            }

            public static class DataStore
            {
                public static string Namespace { get; set; }
                public static string NewLeadKindName { get; set; }
                public static string ChangePhoneKindName { get; set; }
                public static string InvalidSubmissionsKindName { get; set; }
            }
        }

        public static class SendGrid
        {
            public static string ApiKey { get; set; }
        }
    }
}
