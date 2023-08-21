using AutoMapper;
using Contacts.Application.Repositories;
using Contacts.Contracts.Responses;
using Contacts.Domain.Models;
using MediatR;

namespace Contacts.Application.Contacts
{
    public class AddContactHandler : IRequestHandler<AddContactCommand, ContactResponse>
    {
        private readonly IUnitOfWork uow;
        private readonly IContactRepository repository;
        private readonly IMapper mapper;

        public AddContactHandler(IUnitOfWork uow, IContactRepository repository, IMapper mapper)
        {
            this.uow = uow;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ContactResponse> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = this.mapper.Map<Contact>(request.Contact);

            await this.uow.CommitAsync(async () =>
            {
                await this.repository.AddContactAsync(contact);
            });

            return this.mapper.Map<ContactResponse>(contact);
        }
    }
}
