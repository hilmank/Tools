using System;

namespace Migration.Csv2PostgreSQL;

public class Customer
{
    public int Index { get; set; }
    public string CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Phone1 { get; set; }
    public string Phone2 { get; set; }
    public string Email { get; set; }
    public DateTime? SubscriptionDate { get; set; }
    public string Website { get; set; }
}
