using Contacts.Contracts.Requests;
using Contacts.Contracts.Responses;
using MediatR;

namespace Contacts.Application.Contacts
{
    public record AddContactCommand(ContactRequest Contact) : IRequest<ContactResponse>
    {
    }
}
