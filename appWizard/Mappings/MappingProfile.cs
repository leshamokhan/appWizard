using appWizard.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appWizard.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;

            CreateMap<Model, RegisterModelUser>()
                .ForMember(d => d.Salutation, o => o.MapFrom(s => s.StepViewOne.Salutation))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.StepViewOne.FirstName))
                .ForMember(d => d.MiddleName, o => o.MapFrom(s => s.StepViewOne.MiddleName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.StepViewOne.LastName))
                .ForMember(d => d.Company, o => o.MapFrom(s => s.StepViewOne.Company))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.StepViewOne.Title))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.StepViewOne.Email))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.StepViewOne.Phone))
                .ForMember(d => d.Fax, o => o.MapFrom(s => s.StepViewOne.Fax))
                .ForMember(d => d.Mobile, o => o.MapFrom(s => s.StepViewOne.Mobile))
                .ForMember(d => d.Finance, o => o.MapFrom(s => s.StepViewTwo.Finance))
                .ForMember(d => d.Operations, o => o.MapFrom(s => s.StepViewTwo.Operations))
                .ForMember(d => d.IT, o => o.MapFrom(s => s.StepViewTwo.IT))
                .ForMember(d => d.Sales, o => o.MapFrom(s => s.StepViewTwo.Sales))
                .ForMember(d => d.Administrative, o => o.MapFrom(s => s.StepViewTwo.Administrative))
                .ForMember(d => d.Legal, o => o.MapFrom(s => s.StepViewTwo.Legal))
                .ForMember(d => d.Marketing, o => o.MapFrom(s => s.StepViewTwo.Marketing))
                .ForMember(d => d.Comments, o => o.MapFrom(s => s.StepViewTwo.Comments))
                .ForMember(d => d.Country, o => o.MapFrom(s => s.StepViewThree.Country))
                .ForMember(d => d.OfficeName, o => o.MapFrom(s => s.StepViewThree.OfficeName))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.StepViewThree.Address))
                .ForMember(d => d.PostalCode, o => o.MapFrom(s => s.StepViewThree.PostalCode))
                .ForMember(d => d.City, o => o.MapFrom(s => s.StepViewThree.City))
                .ForMember(d => d.State, o => o.MapFrom(s => s.StepViewThree.State))
                .ForMember(d => d.Password, o => o.MapFrom(s => s.StepViewFour.Password))
                .ForMember(d => d.Id, o => o.MapFrom(s => 0))
                .ReverseMap();
        }
    }
}
