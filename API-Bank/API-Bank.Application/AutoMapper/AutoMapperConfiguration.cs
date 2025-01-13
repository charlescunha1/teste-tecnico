using API_Bank.Application.ViewModel;
using API_Bank.Domain.Entities;
using API_Bank.Domain.Enum;
using AutoMapper;

namespace API_Bank.Application.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        //ViewModelToDomain
        CreateMap<CreateBankAccountViewModel, BankAccount>()
        .ForMember(dst => dst.CreatedAt,opts => opts.MapFrom(src => DateTime.Now))
        .ForMember(dst => dst.UpdatedAt,opts => opts.MapFrom(src => DateTime.Now))
        .ForMember(dst => dst.Status,opts => opts.MapFrom(src => Status.ACTIVE));

        //DomainToViewModel
        CreateMap<BankAccount, BankAccountsViewModel>();
        CreateMap<BankAccount, BalanceViewModel>();
        CreateMap<Balance, BalanceViewModel>();
    }
}
