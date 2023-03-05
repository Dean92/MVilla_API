using MVilla_Web.Models;
using MVilla_Web.Models.Models;

namespace MVilla_Web.Services.IService
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
