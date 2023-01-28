using MongoCRUD.Application.Core;
using MongoCRUD.Application.ViewModel;

namespace MongoCRUD.Application.Interfaces;

public interface ICustomerServices
{
    Task<List<ResponseCustomerViewModel>> GetAll();
    Task<ServicesResponse> GetById(string customerId);
    Task<ServicesResponse> Login(string email, string password);

    Task<ServicesResponse> Create(RequestCustomerViewModel customerViewModel);
    Task<ServicesResponse> Update(string customerId, RequestCustomerViewModel customerViewModel);
    Task<ServicesResponse> Activate(string customerId);
    Task<ServicesResponse> Deactivate(string customerId);
    Task<ServicesResponse> Delete(string customerId);
}s