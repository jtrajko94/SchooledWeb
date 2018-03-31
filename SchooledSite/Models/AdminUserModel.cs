using System;

namespace SchooledSite.Models
{
    public class AdminUserModel
    {
        public string AdminUserRowKey { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}