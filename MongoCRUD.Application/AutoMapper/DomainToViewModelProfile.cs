using AutoMapper;
using MongoCRUD.Application.ViewModel;
using MongoCRUD.Domain.Entities;

namespace MongoCRUD.Application.AutoMapper;

public sealed class DomainToViewModelProfile : Profile
{
	public DomainToViewModelProfile()
	{
		CreateMap<Customer, ResponseCustomerViewModel>();
		CreateMap<Customer, ResponseLoginCustomerViewModel>();
	}
}