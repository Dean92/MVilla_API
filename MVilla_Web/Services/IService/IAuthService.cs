using MVilla_Web.Models.Dto;

namespace MVilla_Web.Services.IService
{
	public interface IAuthService
	{
		Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
		Task<T> RegisterAsync<T>(RegisterationRequestDTO objToCreate);
	}
}
