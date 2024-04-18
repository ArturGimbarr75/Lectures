﻿using System.Security.Cryptography;
using System.Text;

namespace _041_Les_Car_API.Services;

public class PasswordHasher : IPasswordHasher
{
	public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
	{
		using var hmac = new HMACSHA512();
		passwordSalt = Convert.ToBase64String(hmac.Key);
		passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
	}

	public bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
	{
		using var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt));
		var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
		return computedHash.SequenceEqual(Convert.FromBase64String(storedHash));
	}
}