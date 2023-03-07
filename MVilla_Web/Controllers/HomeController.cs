using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVilla_Web.Models;
using MVilla_Web.Models.Dto;
using MVilla_Web.Services.IService;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVilla_Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IVillaService _villaService;
		private readonly IMapper _mapper;

		public HomeController(IVillaService villaService, IMapper mapper)
		{
			_villaService = villaService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			List<VillaDTO> list = new();

			var response = await _villaService.GetAllAsync<APIResponse>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
			}

			return View(list);
		}

    }
}