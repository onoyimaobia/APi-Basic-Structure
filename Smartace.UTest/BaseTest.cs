using Microsoft.Extensions.DependencyInjection;
using Smartace.Application;
using System.Reflection;
using MediatR;


namespace Smartace.UTest
{
    public class BaseTest
    {
        protected IServiceCollection GetCollection()
        {
            IServiceCollection service = new ServiceCollection();
           
            AppBootstraper.InitServices(service);
            service.AddLogging();
            service.AddMediatR(Assembly.GetExecutingAssembly());


            return service;
        }
    }
}
