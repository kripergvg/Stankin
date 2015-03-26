using AutoMapper;
using StankinQuestionnaire.Areas.Admin.Models;
using StankinQuestionnaire.Model;
using StankinQuestionnaire.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StankinQuestionnaire.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomain";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CalculationTypeAddModel, CalculationType>();
            Mapper.CreateMap<CalculationTypeFormModel, CalculationType>();
            Mapper.CreateMap<IndicatorAddModel, Indicator>();
            Mapper.CreateMap<IndicatorFormModel, Indicator>();
            Mapper.CreateMap<IndicatorEditModel, Indicator>()
                .ForMember(indicator => indicator.CalculationTypes,
                indicatoreEit => indicatoreEit.Ignore()); ;
        }
    }
}