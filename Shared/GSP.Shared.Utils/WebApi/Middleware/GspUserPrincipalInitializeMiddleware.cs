﻿using GSP.Shared.Utils.Common.UserPrincipal.Contracts;
using GSP.Shared.Utils.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.Middleware
{
    public class GspUserPrincipalInitializeMiddleware
    {
        private readonly RequestDelegate _next;

        public GspUserPrincipalInitializeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private static void SetCurrentUserIfNeeded(ClaimsPrincipal userClaims, IGspUserPrincipal gspUserPrincipal)
        {
            if (userClaims.Identity.IsAuthenticated)
            {
                gspUserPrincipal.SetCurrentUserAccount(userClaims.GetUserId(), userClaims.GetUserEmail());
            }
        }

        public async Task Invoke(HttpContext context, IGspUserPrincipal gspUserPrincipal)
        {
            SetCurrentUserIfNeeded(context.User, gspUserPrincipal);
            await _next(context);
        }
    }
}