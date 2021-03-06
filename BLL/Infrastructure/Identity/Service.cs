﻿using DAL;
using DAL.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using Microsoft.Owin.Security.DataProtection;
using DAL.Entity.Identity;
using DAL.Abstract;

namespace BLL.Infrastructure.Identity
{
    public class Service
    {
        public class EmailService : IIdentityMessageService
        {
            public Task SendAsync(IdentityMessage message)
            {
                // Plug in your email service here to send an email.
                return Task.FromResult(0);
            }
        }

        public class SmsService : IIdentityMessageService
        {
            public Task SendAsync(IdentityMessage message)
            {
                // Plug in your SMS service here to send a text message.
                return Task.FromResult(0);
            }
        }

        // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
        public class ApplicationUserManager : UserManager<AppUser>
        {
            public ApplicationUserManager(IUserStore<AppUser> store, IDataProtectionProvider dataProtectionProvider)
                : base(store)
            {
                // Configure validation logic for usernames
                UserValidator = new UserValidator<AppUser>(this)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                // Configure user lockout defaults
                UserLockoutEnabledByDefault = true;
                DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<AppUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
                RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<AppUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
                EmailService = new EmailService();
                SmsService = new SmsService();
                if (dataProtectionProvider != null)
                {
                    UserTokenProvider =
                        new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                }
            }
            
        }

        // Configure the application sign-in manager which is used in this application.
        public class ApplicationSignInManager : SignInManager<AppUser, string>
        {
            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
                : base(userManager, authenticationManager)
            {
            }

            public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser user)
            {
                return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
            }

            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
            {
                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            }
        }

        public class ApplicationUserStore : UserStore<AppUser>
        {
            public ApplicationUserStore(EFContext context)
                : base(context)
            {
            }
        }
    }
}
