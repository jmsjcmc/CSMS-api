namespace Csms_api.Models
{
    public class PalletRequest
    {
        public string Pallet_type { get; set; }
        public int Pallet_no { get; set; }
        public Boolean Occupied { get; set; }
        public Boolean Active { get; set; }
        public Boolean Removed { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime? Updated_on { get; set; }
        public int User_id { get; set; }
    }

    public class PalletResponse
    {
        public int Id { get; set; }
        public string Pallet_type { get; set; }
        public int Pallet_no { get; set; }
        public Boolean Occupied { get; set; }
        public Boolean Active { get; set; }
        public Boolean Removed { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime? Updated_on { get; set; }
    }

    public class PositionRequest
    {
        public int Cs_id { get; set; }
        public string Section { get; set; }
        public string Pallet_row { get; set; }
        public string Pallet_column { get; set; }
    }

    public class PositionResponse
    {
        public int Id { get; set; }
        public ColdStorageResponse ColdStorage { get; set; }
        public string Section { get; set; }
        public string Pallet_row { get; set; }
        public string Pallet_column { get; set; }
        public Boolean Hidden { get; set; }

    }

    public class ColdstorageRequest
    {
        public string Cs_number { get; set; }
        public Boolean Active { get; set; }
    }

    public class ColdStorageResponse
    {
        public int Id { get; set; }
        public string Cs_number { get; set; }
        public Boolean Active { get; set; }
    }
}
