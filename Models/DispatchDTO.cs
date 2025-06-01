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
}
