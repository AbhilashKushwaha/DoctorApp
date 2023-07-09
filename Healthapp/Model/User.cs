using System;

namespace Healthapp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string emailId { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public bool isActive { get; set; }
        public bool isDoctor { get; set; }
        public string profilePicture { get; set; }
        public DateTime creationDateTime { get; set; } = DateTime.Now;
        public DateTime? lastUpdateDateTime { get; set; } = DateTime.Now;
    }
}
