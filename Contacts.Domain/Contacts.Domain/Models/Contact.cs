namespace Contacts.Domain.Models
{
    public class Contact : Base<Guid>
    {
        public Contact(string firstName, string surname, string phoneNumber, DateTime? DOB, string? address, string? IBAN)
        {
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException("First name must not be empty");
            if (string.IsNullOrEmpty(surname)) throw new ArgumentException("Surname must not be empty");
            if (string.IsNullOrEmpty(phoneNumber)) throw new ArgumentException("Phone number must not be empty");
            if (DOB >= DateTime.Now) throw new ArgumentException("Date of birth must be in the past");
            if (string.IsNullOrEmpty(address)) throw new ArgumentException("Address must not be empty");
            if (string.IsNullOrEmpty(IBAN)) throw new ArgumentException("IBAN must not be empty");

            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.DOB = DOB;
            this.Address = address;
            this.IBAN = IBAN;
        }

        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public DateTime? DOB { get; private set; }
        public string? Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? IBAN { get; private set; }

        // Method to get the full name
        public string GetFullName()
        {
            return $"{FirstName} {Surname}";
        }

        // Method to get age in years
        public int? GetAge()
        {
            if (!DOB.HasValue)
                return null;

            var age = DateTime.Now.Year - DOB.Value.Year;

            // Subtract one from the age if the birthday hasn't occurred yet this year
            if (DateTime.Now.Month < DOB.Value.Month ||
               (DateTime.Now.Month == DOB.Value.Month && DateTime.Now.Day < DOB.Value.Day))
                age--;

            return age;
        }

        public void UpdateName(string firstName, string surname)
        {
            // Validate and update name
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname))
                throw new ArgumentException("Both first name and surname must not be empty");
            FirstName = firstName;
            Surname = surname;
        }

        public void UpdateDOB(DateTime dob)
        {
            // Validate and update date of birth
            if (dob >= DateTime.Now) throw new ArgumentException("Date of birth must be in the past");
            DOB = dob;
        }

        public void UpdateAddress(string address)
        {
            // Validate and update address
            Address = address ?? throw new ArgumentException("Address must not be null");
        }

        public void UpdateIBAN(string iban)
        {
            // Validate and update IBAN
            IBAN = iban ?? throw new ArgumentException("IBAN must not be null");
        }
    }
}
