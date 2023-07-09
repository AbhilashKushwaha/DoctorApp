using System;

namespace Healthapp.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string nsid { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string emailId { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string aadharNumber { get; set; }
        public string profilePicture { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public DateTime creationDateTime { get; set; } = DateTime.Now;
        public DateTime? lastUpdateDateTime { get; set; } = DateTime.Now; 
        public bool isActive { get; set; }
    }
}
