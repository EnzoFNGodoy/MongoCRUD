using AutoMapper;
using MongoCRUD.Application.ViewModel;
using MongoCRUD.Domain.Entities;

namespace MongoCRUD.Application.AutoMapper;

public sealed class ViewModelToDomainProfile : Profile
{
    public ViewModelToDomainProfile()
    {
        CreateMap<RequestCustomerViewModel, Customer>();
    }
}
