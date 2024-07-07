using AutoMapper;
using Planer.Models;
using Planer.Models.Commands;
using Planer.Models.Responses;

namespace Planer.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() {

            CreateMap<Command, Income>();
            CreateMap<Command, Expenses>();

            //CreateMap<List<Income>, List<IncomeExpensesResponse>>();
            //CreateMap<List<Expenses>, List<IncomeExpensesResponse>>();

            CreateMap<Expenses, IncomeExpensesResponse>()
                  .ForMember(d => d.Kind, opt =>
                         opt.MapFrom(x => x.Kind.ToString()));

            CreateMap<Income, IncomeExpensesResponse>()
                 .ForMember(d => d.Kind, opt =>
                        opt.MapFrom(x => x.Kind.ToString()));
        }
    }
}
