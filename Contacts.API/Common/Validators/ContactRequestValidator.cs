using Contacts.Contracts.Requests;
using FluentValidation;

namespace Contacts.API.Common.Validators
{
    public class ContactRequestValidator : AbstractValidator<ContactRequest>
    {
        public ContactRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(x => x.Address)
                .MaximumLength(100);

            RuleFor(x => x.DOB)
                .LessThan(DateTime.Today);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.IBAN).Length(34); 
        }
    }
}
