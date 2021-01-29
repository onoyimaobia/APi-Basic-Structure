using Microsoft.Extensions.DependencyInjection;
using Smartace.Application;
using MediatR;
using System.Reflection;


namespace Smartace.Test
{
    public class BaseTest
    {
        protected IServiceCollection GetCollection()
        {
            IServiceCollection service = new ServiceCollection();
            
            AppBootstraper.InitServices(service);
            //service.AddLogging();
            service.AddMediatR(Assembly.GetExecutingAssembly());
            

            return service;
        }
    }
}
