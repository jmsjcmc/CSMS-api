namespace Csms_api.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company_name { get; set; }
        public string Company_address { get; set; }
        public string Company_email { get; set; }
        public string Company_number { get; set; }
        public int Creator_id { get; set; }
        public DateTime Created_on { get; set; }
        public int? Updater_id { get; set; }
        public DateTime? Updated_on { get; set; }
        public Boolean Active { get; set; }
        public Boolean? Removed { get; set; }
        public List<Product> Product { get; set; } = new List<Product>();
    }
}
