using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVilla_Web.Models.Dto;

namespace MVilla_Web.Models.Models.Vm
{
	public class VillaNumberDeleteVM
	{
		public VillaNumberDeleteVM()
		{
			VillaNumber = new VillaNumberDTO();
		}
		public VillaNumberDTO VillaNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> VillaList { get; set; }
	}
}
