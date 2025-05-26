namespace Csms_api.Models
{
    public class Receiving
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Document_id { get; set; }
        public Document Document { get; set; }
        public int Product_id { get; set; }
        public Product Product { get; set; }
        public string Expiration_date { get; set; }
        public string Cv_number { get; set; }
        public string Plate_number { get; set; }
        public string Arrival_date { get; set; }
        public string Unloading_start { get; set; }
        public string Unloading_end { get; set; }
        public string? Note { get; set; }
        public double Overall_weight { get; set; }
        public string? Temperature { get; set; }
        public string? Production_date { get; set; }
        public int Creator_id { get; set; }
        public DateTime Created_on { get; set; }
        public int Updater_id { get; set; }
        public DateTime Updated_on { get; set; }
        public int Reviewer_id { get; set; }
        public DateTime? Date_received { get; set; }
        public DateTime? Date_declined { get; set; }
        public string Receiving_form { get; set; }
        public Boolean Pending { get; set; }
        public Boolean Received { get; set; }
        public Boolean Declined { get; set; }
        public Boolean Dispatched { get; set; }
        public Boolean Removed { get; set; }
        public List<ReceivingDetail> Receiving_detail { get; set; } = new List<ReceivingDetail>();
    }

    public class ReceivingDetail
    {
        public int Id { get; set; }
        public int Receiving_id { get; set; }
        public Receiving Receiving { get; set; }
        public int Position_id { get; set; }
        public PalletPosition Pallet_position { get; set; }
        public int Pallet_number { get; set; }
        public int Quantity_in_pallet { get; set; }
        public double Total_weight { get; set; }
        public Boolean Received { get; set; }
        public Boolean Dispatched { get; set; }

    }

    public class Document
    {
        public int Id { get; set; }
        public string Document_number { get; set; }
        public Receiving Receiving { get; set; }

    }
}
