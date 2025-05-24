namespace Csms_api.Models
{
    public class Pallet
    {
        public int Id { get; set; }
        public string Pallet_type { get; set; }
        public int Pallet_no { get; set; }
        public Boolean Occupied { get; set; }
        public Boolean Active { get; set; }
        public Boolean Removed { get; set; }
        public int Creator_id { get; set; }
        public DateTime Created_on { get; set; }
        public int? Updated_id { get; set; }
        public DateTime? Updated_on { get; set; }
    }
}
