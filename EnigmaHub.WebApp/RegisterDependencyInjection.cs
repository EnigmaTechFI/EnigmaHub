
using EnigmaHub.Domain.Context;
using EnigmaHub.Service.Implementation;
using EnigmaHub.Service.Interface;
using EnigmaHub.Service.Repositories;
using EnigmaHubHelper.Helper;

namespace EliteDomus.WebApp;

public static class RegisterDependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
        #region Repository Dependency Injection
        serviceCollection.AddScoped<IEnigmaHubUoW<CustomerMarketingData>, EnigmaHubUoW<CustomerMarketingData>>();
        serviceCollection.AddScoped<IEnigmaHubUoW<Customer>, EnigmaHubUoW<Customer>>();
        #endregion
        
        #region Service Dependency Injection
        serviceCollection.AddTransient<ICustomerService, CustomerService>();
        #endregion

        #region Utils Dependency Injection
        
        #endregion
    
        #region Validator Dependency Injection
        #endregion

        #region Helper Dependency Injection
        serviceCollection.AddTransient<CustomerHelper>();
        #endregion
        
        return serviceCollection;
    }
}