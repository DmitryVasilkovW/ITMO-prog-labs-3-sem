using LabWork5.Application.ATMs;
using LabWork5.Application.Contracts.ATMs;
using LabWork5.Application.Contracts.Users;
using LabWork5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LabWork5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IATMService, ATMService>();

        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());

        return collection;
    }
}