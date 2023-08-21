namespace Contacts.Contracts.Requests
{
    public class ContactRequest
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string IBAN { get; set; }
    }
}
