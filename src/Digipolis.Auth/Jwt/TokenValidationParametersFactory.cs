﻿using Microsoft.IdentityModel.Tokens;
using System;
using Digipolis.Auth.Options;

namespace Digipolis.Auth.Jwt
{
    public class TokenValidationParametersFactory
    {
        public static TokenValidationParameters Create(AuthOptions authOptions, IJwtTokenSignatureValidator signatureValidator)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidAudience = authOptions.JwtAudience,
                ValidateIssuer = true,
                ValidIssuer = authOptions.JwtIssuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(authOptions.JwtValidatorClockSkew),
                NameClaimType = "sub",
                SignatureValidator = signatureValidator.SignatureValidator
            };
            
            return tokenValidationParameters;
        }
    }
}