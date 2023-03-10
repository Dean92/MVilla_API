
using MVilla_Web.Models.Models.Dto;

namespace MVilla_Web.Models.Dto
{
	public class LoginResponseDTO
	{
		public UserDTO User { get; set; }
		public string Token { get; set; }
	}
}
