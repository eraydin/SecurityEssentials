﻿using Microsoft.AspNet.Identity;
using SecurityEssentials.Model;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SecurityEssentials.Core.Identity
{
	public interface IAppUserStore<T> : IUserStore<T, int>, IUserPasswordStore<T, int>, IDisposable where T : class, IUser<int>
	{

		Task<int> ChangePasswordAsync(int userId, string currentPassword, string newPassword);

		Task<LogonResult> TryLogOnAsync(string userName, string password);

		Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);

		Task<IdentityResult> ChangePasswordFromTokenAsync(int userId, string passwordResetToken, string newPassword);
		Task<IdentityResult> ResetPasswordAsync(int userId, string newPassword, string actioningUserName);
	}
}