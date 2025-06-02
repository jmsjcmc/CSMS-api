namespace Csms_api.Models
{
    public class ReceivingRequest
    {
        public string Category { get; set; }
        public string Document_number { get; set; }
        public int Product_id { get; set; }
        public string Expiration_date { get; set; }
        public string Cv_number { get; set; }
        public string Plate_number { get; set; }
        public string Arrival_date { get; set; }
        public string Unloading_start { get; set; }
        public string Unloading_end { get; set; }
        public double Overall_weight { get; set; }
        public string? Temperature { get; set; }
        public string? Production_date { get; set; }
        public string Receiving_form { get; set; }
        public List<ReceivingDetailRequest> Receiving_detail { get; set; } = new List<ReceivingDetailRequest>();
    }

    public class ReceivingResponse
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Document_id { get; set; }
        public int Product_id { get; set; }
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
        public List<ReceivingDetailResponse> Receiving_detail { get; set; }
    }

    public class ReceivingDetailRequest
    {
        public int Receiving_id { get; set; }
        public int Pallet_id { get; set; }
        public int Quantity_in_pallet { get; set; }
        public double Total_weight { get; set; }
    }

    public class ReceivingDetailResponse
    {
        public int Id { get; set; }
        public int Quantity_in_pallet { get; set; }
        public double Total_weight { get; set; }
        public Boolean Received { get; set; }
        public Boolean Dispatched { get; set; }
        public PalletResponse Pallet { get; set; }
    }

    public class DocumentNumberResponse
    {
        public string Document_number { get; set; }
    }
}
