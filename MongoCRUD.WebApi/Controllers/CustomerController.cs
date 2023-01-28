using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoCRUD.Application.Interfaces;
using MongoCRUD.Application.ViewModel;
using MongoDB.Bson;

namespace MongoCRUD.WebApi.Controllers;

[Route("customers")]
public sealed class CustomerController : ApiController
{
    private readonly ICustomerServices _customerServices;

    public CustomerController(ICustomerServices customerServices)
    {
        _customerServices = customerServices;
    }

    /// <summary>
    /// Recupera todos os registros de Clientes.
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
        => Ok(await _customerServices.GetAll());

    /// <summary>
    /// Recupera somente o registro do Cliente com o Id especificado na URL.
    /// </summary>
    [HttpGet]
    [Route("{customerId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(string customerId)
    {
        try
        {
            var response = await _customerServices.GetById(customerId);

            if (response.IsSuccess)
                return Ok(response.Response);

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Realiza o Login e retorna o Token para autenticação.
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] RequestLoginCustomerViewModel viewModel)
    {
        try
        {
            var response = await _customerServices.Login(viewModel.Email, viewModel.Password);

            if (response.IsSuccess)
                return Ok(response.Response);

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Cadastra um Cliente.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] RequestCustomerViewModel viewModel)
    {
        try
        {
            var response = await _customerServices.Create(viewModel);

            if (response.IsSuccess)
                return Ok(response.Response);

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza um Cliente.
    /// </summary>
    [HttpPut("{customerId}")]
    [Authorize]
    public async Task<IActionResult> Put([FromBody] RequestCustomerViewModel viewModel, string customerId)
    {
        try
        {
            var response = await _customerServices.Update(customerId, viewModel);

            if (response.IsSuccess)
                return Ok(response.Response);

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Deleta um Cliente.
    /// </summary>
    [HttpDelete("{customerId}")]
    [Authorize]
    public async Task<IActionResult> Delete(string customerId)
    {
        try
        {
            var response = await _customerServices.Delete(customerId);

            if (response.IsSuccess)
                return Ok(response.Message);

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Ativa um Cliente.
    /// </summary>
    [HttpPatch("activate/{customerId}")]
    [Authorize]
    public async Task<IActionResult> Activate(string customerId)
    {
        try
        {
            var response = await _customerServices.Activate(customerId);

            if (response.IsSuccess)
                return Ok(response.Message);

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Desativa um Cliente.
    /// </summary>
    [HttpPatch("deactivate/{customerId}")]
    [Authorize]
    public async Task<IActionResult> Deactivate(string customerId)
    {
        try
        {
            var response = await _customerServices.Deactivate(customerId);

            if (response.IsSuccess)
                return Ok(response.Message);

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}