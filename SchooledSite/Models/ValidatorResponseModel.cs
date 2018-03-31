using System.Collections.Generic;

namespace SchooledSite.Models
{
    public class ValidatorResponseModel
    {
        public bool IsValid { get; set; }
        public Dictionary<string,string> ErrFields { get; set; }
    }
}