using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVilla_Web.Models.Dto;

namespace MVilla_Web.Models.Models.Vm
{
	public class VillaNumberCreateVM
	{
		public VillaNumberCreateVM()
		{
			VillaNumber = new VillaNumberCreateDTO();
		}
		public VillaNumberCreateDTO VillaNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> VillaList { get; set; }
	}
}
