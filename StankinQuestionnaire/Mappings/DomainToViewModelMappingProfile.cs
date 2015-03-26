using AutoMapper;
using StankinQuestionnaire.Areas.Admin.Models;
using StankinQuestionnaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StankinQuestionnaire.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModel";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CalculationType, CalculationTypeFormModel>();
            Mapper.CreateMap<Indicator, IndicatorFormModel>()
                .ForMember(indicatorForm => indicatorForm.CalculationTypes,
                indicator => indicator.Ignore());
            Mapper.CreateMap<CalculationType, CalculationTypeSelect>();
        }
    }
}