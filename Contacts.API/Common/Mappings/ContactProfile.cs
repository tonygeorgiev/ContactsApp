using AutoMapper;
using Contacts.Contracts.Requests;
using Contacts.Contracts.Responses;
using Contacts.Domain.Models;

namespace Contacts.API.Common.Mappings
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactResponse, ContactRequest>()
                .ReverseMap();
            CreateMap<ContactRequest, Contact>()
                .ReverseMap();
            CreateMap<ContactResponse, Contact>()
                .ReverseMap();
        }
    }
}
