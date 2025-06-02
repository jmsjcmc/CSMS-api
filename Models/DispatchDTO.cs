namespace Csms_api.Models
{
    public class DispatchRequest
    {
        public int Product_id { get; set; }
        public string Document_number { get; set; }
        public string Dispatch_date { get; set; }
        public string Time_start { get; set; }
        public string Time_end { get; set; }
        public string Nmis_certificate { get; set; }
        public string Plate_no { get; set; }
        public string Seal_no { get; set; }
        public double Overall_weight { get; set; }
        public string? Temperature { get; set; }
        public string? Production_date { get; set; }
    }

    public class DispatchResponse
    {
        public int Id { get; set; }
        public string Document_number { get; set; }
        public string Dispatch_date { get; set; }
        public string Time_start { get; set; }
        public string Time_end { get; set; }
        public string Nmis_certificate { get; set; }
        public string Plate_no { get; set; }
        public string Seal_no { get; set; }
        public double Overall_weight { get; set; }
        public string Temperature { get; set; }
        public string Production_date { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime Updated_on { get; set; }
        public DateTime Approved_on { get; set; }
        public DateTime Declined_on { get; set; }
        public Boolean Removed { get; set; }
        public Boolean Dispatched { get; set; }
        public Boolean Pending { get; set; }
        public Boolean Declined { get; set; }
        public ProductResponse Product { get; set; }
        public UserResponse Creator { get; set; }
        public UserResponse Reviewer { get; set; }
    }

    public class DispatchDetailRequest
    {
        public int Dispatching_id { get; set; }
        public int ReceivingDetail_id { get; set; }
        public int Pallet_id { get; set; }
        public int Quantity_in_pallet { get; set; }
    }
}
