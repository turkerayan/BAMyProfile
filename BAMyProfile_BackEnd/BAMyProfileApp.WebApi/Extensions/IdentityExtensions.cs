﻿using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Dtos.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BAMyProfileApp.WebApi.Extensions;


public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWTOption>(configuration.GetSection("TokenOptions"));
        var jwtOptions = configuration.GetSection("TokenOptions").Get<JWTOption>();
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            // Authorization koşulunun dönüş kodlarının uygunluğunu sağlamak için eklendi:
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //İki ayrı üyelik sistemi olarabir bayiler için ayrı üyelik olabilir. Kullanıcılar için farklı bir login olabilir. Burada farklı iki şema ekleyebilirdik  bizde tek var onun için sabit bir JwtBearerDefaults kullanıyorum.
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {// burada jwt içindeki verilerin birbirinii nasıl doğrulayacağını belirttiğimiz bir yapı kuruyoruz. Bu karsı tarafın istek yaptığında benim projeme onuun verileri
                ValidIssuer = jwtOptions.Issuer,// hangi Issurerdan veri geleceğini belirttik.
                ValidAudience = jwtOptions.Audience[0],
                // burada hangi proje istek yapacak onu belirttik.
                ValidateIssuerSigningKey = true,// imzayı doğrulasın mı?
                ValidateAudience = true, // audience doğrula 
                ValidateLifetime = true,// Ömrünün geçerli olup olmadığını kontrol et.
                IssuerSigningKey = SignService.GetSymmetricSecurityKey(jwtOptions.SecurityKey),// gelen imzayı neye göre doğrulayacağını belirtiyoruz.
                ClockSkew = TimeSpan.Zero
                // farklı serverlarda farklı zaman dilimlerinde istek için ömür belirlenebilir onun için identity kütüp. default değerinin 1 saat vermisse bize 1 saat 5 dk ömürle çıkar bunu hataları minimize etmek için  yapar biz onu minimize ediyoruz.
            };

        });

        return services;
    }
}

