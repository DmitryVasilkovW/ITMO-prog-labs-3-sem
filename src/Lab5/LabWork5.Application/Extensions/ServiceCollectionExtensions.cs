using LabWork5.Application.Admins;
using LabWork5.Application.Contracts.Admins;
using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LabWork5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        return collection;
    }
}