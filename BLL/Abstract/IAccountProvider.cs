﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BLL.Abstract
{
    public interface IAccountProvider
    {
        Task<SignInStatus> Login(LoginViewModel model, string returnUrl);

        Task<bool> HasBeenVerifiedAsync();

        Task<SignInStatus> VerifyCode(VerifyCodeViewModel model);

        Task<IdentityResult> Register(RegisterViewModel model);

        Task<string> ConfirmEmail(string userId, string code);

        Task<bool> ForgotPassword(ForgotPasswordViewModel model);

        Task<string> GetUserIdByEmail(string email);

        Task<bool> UserWithNameExists(string email);

        Task<IdentityResult> ResetPassword(string email, string code, string password);

        Task<string> GetVerifiedUserIdAsync();

        Task<IEnumerable<string>> GetValidTwoFactorProvidersAsync(string userId);

        Task<bool> SendCode(string selectedProvider);

        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo);

        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();

        Task<IdentityResult> CreateUserAsync(ExternalLoginConfirmationViewModel model);

        Task<IdentityResult> AddLoginAsync(string email, UserLoginInfo login);

        Task SignInAsync(string email, bool isPersistent, bool rememberBrowser);
        

        void LogOff();
    }
}
