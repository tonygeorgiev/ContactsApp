namespace Contacts.Contracts.Responses
{
    public class ContactResponse
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public DateTime DOB { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string IBAN { get; private set; }
    }
}