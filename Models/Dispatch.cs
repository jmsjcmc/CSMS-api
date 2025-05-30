namespace Csms_api.Models
{
    public class Dispatch
    {
        public int Id { get; set; }
        public string Product_id { get; set; }
        public Product Product { get; set; }
        public int Document_id { get; set; }
        public Document Document { get; set; }
        public string Dispatch_date { get; set; }
        public string Time_start { get; set; }
        public string Time_end { get; set; }
        public string Nmis_certificate { get; set; }
        public string Plate_no { get; set; }
        public string Seal_no { get; set; }
        public double Overall_weight { get; set; }
        public string? Temperature { get; set; }
        public string? Production_date { get; set; }
        public int Creator_id { get; set; }
        public DateTime Created_on { get; set; }
        public int Updated_id { get; set; }
        public DateTime Updated_on { get; set; }
        public int Reviewer_id { get; set; }
        public DateTime Approved_on { get; set; }
        public DateTime? Declined_on { get; set; }
        public Boolean Removed { get; set; }
        public Boolean Dispatched { get; set; }
        public Boolean Pending { get; set; }
        public Boolean Declined { get; set; }
        public List<DispatchDetail> Details { get; set; } = new List<DispatchDetail>();
    }

    public class DispatchDetail
    {
        public int Id { get; set; }
        public int Dispatching_id { get; set; }
        public Dispatch Dispatch { get; set; }
        public int ReceivingDetail_id { get; set; }
        public ReceivingDetail Receiving_detail { get; set; }
        public int Position_id { get; set; }
        public PalletPosition Position { get; set; }
        public int Pallet_number { get; set; }
        public int Quantity_in_pallet { get; set; }
        public Boolean Dispatched { get; set; }
    }
}
