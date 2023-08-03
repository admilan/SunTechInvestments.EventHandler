using System.Net.Mail;
using System.Text.Json;

namespace SunTechInvestments.EventHandler.Domain.Entities;

public class CustomerInfo
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthdayInEpoch { get; set; }
    public string EmailAddress { get; set; }

    public override string ToString()
    {
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Serialize(this, serializeOptions);
    }
    private CustomerInfo() { }
    private CustomerInfo(string id, string firstName, string lastName, string birthdayInEpoch, string emailAddress)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthdayInEpoch = birthdayInEpoch;
        EmailAddress = emailAddress;
    }

    public static CustomerInfo Create(string id, string firstName, string lastName, string birthdayInEpoch, string emailAddress) => new CustomerInfo(id, firstName, lastName, birthdayInEpoch, emailAddress);
}
    
