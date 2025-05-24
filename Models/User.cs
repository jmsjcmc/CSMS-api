namespace Csms_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public Boolean Removed { get; set; }
        public string? E_signature { get; set; }
        public DateTime Created_on { get; set; }
        public DateTime? Updated_on { get; set; }
        public int BusinessUnit_id { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
    }

    public class BusinessUnit
    {
        public int Id { get; set; }
        public string Business_unit { get; set; }
        public string BusinessUnit_location { get; set; }
        public Boolean Removed { get; set; }
        public List<User> User { get; set; } = new List<User>();
    }

    public class Role
    {
        public int Id { get; set; }
        public string Role_name { get; set; }
        public Boolean Removed { get; set; }
    }
}
