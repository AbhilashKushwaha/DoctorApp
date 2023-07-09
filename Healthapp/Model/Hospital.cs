namespace Healthapp.Model
{
    public class Hospital
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string emailId { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string logoPath { get; set; }
        public string zipcode { get; set; }
        public bool isActive { get; set; }
    }
}
