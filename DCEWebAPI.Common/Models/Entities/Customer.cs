﻿

namespace DCEWebAPI.Common.Models.Entities
{
    public class Customer
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive {  get; set; }
    }
}
