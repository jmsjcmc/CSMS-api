namespace Csms_api.Models
{
    public class Paginate<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Total_count { get; set; }
        public int Page_number { get; set; }
        public int Page_size { get; set; }
    }

    public class UserRequest
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public List<string> Roles { get; set; }
        public int BusinessUnit_id { get; set; }
    }

    public class UserResponse
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string E_signature { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime Updated_on { get; set; }
        public string Business_unit { get; set; }
        public string BusinessUnit_location { get; set; }
    }

    public class BusinessUnitRequest
    {
        public string Business_unit { get; set; }
        public string BusinessUnit_location { get; set; }
    }

    public class BusinessUnitResponse
    {
        public int Id { get; set; }
        public string Business_unit { get; set; }
        public string BusinessUnit_location { get; set; }
    }
}
