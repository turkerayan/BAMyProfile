using BAMyProfileApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using BAMyProfileApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BAMyProfileApp.DataAccess.EFCore.Seeds;

internal static class AdminSeed
{
    private const string AdminEmail = "admin@bamyprofileapp.com";
    private const string AdminPassword = "newPassword+0";

    public static async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder<BAMyProfileAppDbContext>();

        dbContextBuilder.UseSqlServer(configuration.GetConnectionString(BAMyProfileAppDbContext.ConnectionName));

        using BAMyProfileAppDbContext context = new (dbContextBuilder.Options);

        if (!context.Roles.Any())
        {
            await AddRoles(context);
        }
        if (!context.Users.Any(user => user.Email == AdminEmail))
        {
            await AddAdmin(context);
        }
        await Task.CompletedTask;
    }

    private static async Task AddAdmin(BAMyProfileAppDbContext context)
    {
        IdentityUser user = new()
        {
            UserName = AdminEmail,
            NormalizedUserName = AdminEmail.ToUpper(),
            Email = AdminEmail,
            NormalizedEmail = AdminEmail.ToUpper(),
            EmailConfirmed = true
        };
        user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, AdminPassword);
        await context.Users.AddAsync(user);

        var adminRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString())!.Id;

        await context.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = user.Id, RoleId = adminRoleId });

        await context.SaveChangesAsync();
    }

    private static async Task AddRoles(BAMyProfileAppDbContext context)
    {
        string[] roles = Enum.GetNames(typeof(Roles));
        for (int i = 0; i < roles.Length; i++)
        {
            if (await context.Roles.AnyAsync(role => role.Name == roles[i]))
            {
                continue;
            }

            await context.Roles.AddAsync(new IdentityRole(roles[i]));
        }
    }
}

