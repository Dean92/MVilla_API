﻿using Microsoft.Extensions.Configuration.Xml;
using Microsoft.IdentityModel.Tokens;
using MVilla_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Villa_API.Data;
using Villa_API.Models.Dto;
using Villa_API.Repository.IRepository;

namespace Villa_API.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDBContext _db;
		private string secretKey;

		public UserRepository(ApplicationDBContext db, IConfiguration configuration) { 
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:Secret");
		}

		public bool IsUniqueUser(string username)
		{
			var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
			if (user == null)
			{
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _db.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() && u.Password == loginRequestDTO.Password);

			if (user == null)
			{
				return new LoginResponseDTO()
				{
					Token = "",
					User = null
				};
			}

			//if user was found, generate JWT Token

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
			{
				Token = tokenHandler.WriteToken(token),
				User = user
			};
			return loginResponseDTO;
		}

		public async Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
		{
			LocalUser user = new()
			{
				UserName = registerationRequestDTO.UserName,
				Password = registerationRequestDTO.Password,
				Name = registerationRequestDTO.Name,
				Role = registerationRequestDTO.Role
			};

			_db.LocalUsers.Add(user);
			await _db.SaveChangesAsync();
			user.Password = "";
			return user;
		}
	}
}
