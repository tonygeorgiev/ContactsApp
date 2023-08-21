using Contacts.Contracts.Responses;
using MediatR;

namespace Contacts.Application.Contacts
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactResponse>>
    {
    }
}
