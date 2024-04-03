using Microsoft.AspNetCore.Mvc;

namespace _040_Les_Product_API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CustomerController : ControllerBase
{
	/*private readonly ICustomerService _customerService;

	public CustomerController(ICustomerService customerService)
	{
		_customerService = customerService;
	}*/
	/*
	[HttpGet(Name = nameof(GetCustomers))]
	public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
	{
		//return await _customerService.GetCustomers();
		throw new NotImplementedException();
	}

	[HttpGet("{id}", Name = nameof(GetCustomer))]
	public async Task<ActionResult<Customer?>> GetCustomer(int id)
	{
		return await _customerService.GetCustomer(id);
	}

	[HttpPost(Name = nameof(CreateCustomer))]
	public async Task<ActionResult<Customer?>> CreateCustomer(Customer customer)
	{
		return await _customerService.CreateCustomer(customer);
	}

	[HttpPut(Name = nameof(UpdateCustomer))]
	public async Task<ActionResult<Customer?>> UpdateCustomer(Customer customer)
	{
		return await _customerService.UpdateCustomer(customer);
	}*/

	[HttpDelete(Name = nameof(DeleteCustomer))]
	public async Task<ActionResult> DeleteCustomer(int id)
	{
		throw new NotImplementedException();
		//return await _customerService.DeleteCustomer(id);
	}
}
