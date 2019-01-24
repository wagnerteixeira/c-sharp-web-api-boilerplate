using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Services.Interfaces;
using Application.Domain.Services;
using Application.Infra;

namespace Application.Application.IoC
{

    public static class KernelFactory
    {
        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));            
            kernel.Bind<IPersonService>().To<PersonService>();
         //   kernel.Bind(BaseContext);
        }
    }

}
