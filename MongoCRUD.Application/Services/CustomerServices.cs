using AutoMapper;
using MongoCRUD.Application.Auth;
using MongoCRUD.Application.Core;
using MongoCRUD.Application.Interfaces;
using MongoCRUD.Application.ViewModel;
using MongoCRUD.Domain.Entities;
using MongoCRUD.Domain.Helpers;
using MongoCRUD.Domain.Interfaces;
using MongoCRUD.Domain.ValueObjects;
using MongoDB.Bson;

namespace MongoCRUD.Application.Services;

public sealed class CustomerServices : ICustomerServices
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerServices(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<List<ResponseCustomerViewModel>> GetAll()
        => _mapper.Map<List<ResponseCustomerViewModel>>(await _customerRepository.GetAll());

    public async Task<ServicesResponse> GetById(string customerId)
    {
        if (!ObjectId.TryParse(customerId, out ObjectId customerIdParsed))
            return new ServicesResponse(false, "Id inválido.");

        var customerMapped = _mapper.Map<ResponseCustomerViewModel>(await _customerRepository.GetOneWhere(x => x.Id == customerIdParsed));

        return new ServicesResponse(true, "Sucesso.", customerMapped);
    }

    public async Task<ServicesResponse> Login(string email, string password)
    {
        if (email.IsEmpty())
            return new ServicesResponse(false, "Email inválido.");

        if (password.IsEmpty())
            return new ServicesResponse(false, "Password inválido.");

        var customerExists = await _customerRepository.GetOneWhere(x => x.Email.Address == email && x.Password.PasswordTyped == password);

        if (customerExists is null)
            return new ServicesResponse(false, "Cliente inexistente.");

        var token = TokenServices.GenerateToken(customerExists);

        var customerMapped = _mapper.Map<ResponseLoginCustomerViewModel>(customerExists);
        customerMapped.Token = token;

        return new ServicesResponse(true, "Sucesso.", customerMapped);
    }

    public async Task<ServicesResponse> Create(RequestCustomerViewModel customerViewModel)
    {
        var name = new Name(customerViewModel.FirstName, customerViewModel.LastName);
        var email = new Email(customerViewModel.Email);
        var password = new Password(customerViewModel.Password);
        var customer = new Customer(name, email, password);

        if (!customer.IsValid)
            return new ServicesResponse(false, "Cliente inválido. Favor verificar os campos digitados.", customer.Notifications);

        await _customerRepository.Create(customer);

        var customerMapped = _mapper.Map<ResponseCustomerViewModel>(customer);

        return new ServicesResponse(true, "Cliente criado com sucesso.", customerMapped);
    }

    public async Task<ServicesResponse> Update(string customerId, RequestCustomerViewModel customerViewModel)
    {
        var name = new Name(customerViewModel.FirstName, customerViewModel.LastName);
        var email = new Email(customerViewModel.Email);
        var password = new Password(customerViewModel.Password);

        if (!ObjectId.TryParse(customerId, out ObjectId customerIdParsed))
            return new ServicesResponse(false, "Id inválido.");

        var customer = await _customerRepository.GetOneWhere(x => x.Id == customerIdParsed);

        if(customer is null)
            return new ServicesResponse(false, "Cliente inexistente.");

        customer.Update(name, email, password);

        if (!customer.IsValid)
            return new ServicesResponse(false, "Cliente inválido. Favor verificar os campos digitados.", customer.Notifications);

        await _customerRepository.Update(customer);

        var customerMapped = _mapper.Map<ResponseCustomerViewModel>(customer);

        return new ServicesResponse(true, "Cliente atualizado com sucesso.", customerMapped);
    }

    public async Task<ServicesResponse> Activate(string customerId)
    {
        if (!ObjectId.TryParse(customerId, out ObjectId customerIdParsed))
            return new ServicesResponse(false, "Id inválido.");

        var customer = await _customerRepository.GetOneWhere(x => x.Id == customerIdParsed);

        if (customer is null)
            return new ServicesResponse(false, "Cliente inexistente.");

        customer.Activate();

        if (!customer.IsActive)
            return new ServicesResponse(false, "Cliente inválido. Favor verificar os campos digitados.");

        await _customerRepository.Update(customer);

        var customerMapped = _mapper.Map<ResponseCustomerViewModel>(customer);

        return new ServicesResponse(true, "Cliente habilitado com sucesso.", customerMapped);
    }

    public async Task<ServicesResponse> Deactivate(string customerId)
    {
        if (!ObjectId.TryParse(customerId, out ObjectId customerIdParsed))
            return new ServicesResponse(false, "Id inválido.");

        var customer = await _customerRepository.GetOneWhere(x => x.Id == customerIdParsed);

        if (customer is null)
            return new ServicesResponse(false, "Cliente inexistente.");

        customer.Deactivate();

        if (customer.IsActive)
            return new ServicesResponse(false, "Cliente inválido. Favor verificar os campos digitados.");

        await _customerRepository.Update(customer);

        var customerMapped = _mapper.Map<ResponseCustomerViewModel>(customer);

        return new ServicesResponse(true, "Cliente desabilitado com sucesso.", customerMapped);
    }

    public async Task<ServicesResponse> Delete(string customerId)
    {
        if (!ObjectId.TryParse(customerId, out ObjectId customerIdParsed))
            return new ServicesResponse(false, "Id inválido.");

        var customer = await _customerRepository.GetOneWhere(x => x.Id == customerIdParsed);

        if (customer is null)
            return new ServicesResponse(false, "Cliente inexistente.");

        await _customerRepository.Delete(customer.Id);

        var customerMapped = _mapper.Map<ResponseCustomerViewModel>(customer);

        return new ServicesResponse(true, "Cliente deletado com sucesso.", customerMapped);
    }
}