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

            CreateMap<Contact, ContactResponse>()
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.GetFullName()))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.GetAge().Value)) // Make sure DOB is always set in Contact or handle potential null value
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
