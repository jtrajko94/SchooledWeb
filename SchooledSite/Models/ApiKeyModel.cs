using System;

namespace SchooledSite.Models
{
    public class ApiKeyModel
    {
        public Guid APIKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}