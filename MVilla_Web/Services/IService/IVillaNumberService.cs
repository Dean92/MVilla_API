﻿
using MVilla_Web.Models.Dto;

namespace MVilla_Web.Services.IService
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaNumberCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
