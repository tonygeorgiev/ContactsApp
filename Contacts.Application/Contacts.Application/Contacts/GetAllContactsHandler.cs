using AutoMapper;
using Contacts.Contracts.Responses;
using Contacts.Application.Repositories;
using MediatR;

namespace Contacts.Application.Contacts
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactResponse>>
    {
        private readonly IContactRepository repository;
        private readonly IMapper mapper;

        public GetAllContactsHandler(IContactRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ContactResponse>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await this.repository.GetAllContactsAsync();

            return this.mapper.Map<IEnumerable<ContactResponse>>(contacts);
        }
    }
}
