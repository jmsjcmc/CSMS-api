namespace Csms_api.Models
{
    public class ProductRequest
    {
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
        public int Company_id { get; set; }
    }
    public class ProductResponse
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
        public CompanyResponse Company { get; set; }
    }
}
