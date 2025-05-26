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

    public class PalletPosition
    {
        public int Id { get; set; }
        public int Cs_id { get; set; }
        public ColdStorage ColdStorage { get; set; }
        public string Section { get; set; }
        public string Pallet_row { get; set; }
        public string Pallet_column { get; set; }
        public Boolean Hidden { get; set; }
        public Boolean Removed { get; set; }
        public List<ReceivingDetail> ReceivingDetails { get; set; } = new List<ReceivingDetail>();
    }

    public class ColdStorage
    {
        public int Id { get; set; }
        public string Cs_number { get; set; }
        public Boolean Active { get; set; }
        public List<PalletPosition> PalletPosition { get; set; } = new List<PalletPosition>();
    }
}
