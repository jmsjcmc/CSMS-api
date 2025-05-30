namespace Csms_api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Product_code { get; set; }
        public string Product_name { get; set; }
        public string Variant { get; set; }
        public string Sku { get; set; }
        public string Product_packaging { get; set; }
        public string Delivery_unit { get; set; }
        public int Quantity { get; set; }
        public string Uom { get; set; }
        public double Weight { get; set; }
        public string Unit { get; set; }
        public Boolean Active { get; set; }
        public Boolean Removed { get; set; }
        public int Creator_id { get; set; }
        public DateTime Created_on { get; set; }
        public int? Updater_id { get; set; }
        public DateTime? Updated_on { get; set; }
        public int Company_id { get; set; }
        public Company Company { get; set; }
        public Receiving Receiving { get; set; }
        public Dispatch Dispatch { get; set; }
    }
}
