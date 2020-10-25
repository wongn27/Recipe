﻿using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Web.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email = await _sessionStorageService.GetItemAsync<string>("email");

            ClaimsIdentity identity;

            if (email != null)
            {
                identity = new ClaimsIdentity(new[]
               {
                    new Claim(ClaimTypes.Name, email),
               }, "databaseauth_type");
            }
            else
            {
                 identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string email)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email),
            }, "databaseauth_type");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _sessionStorageService.RemoveItemAsync("email");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
