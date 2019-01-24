using Application.Application.IoC;
using Application.Domain.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public static class Services
    {
        public static StandardKernel Kernel = KernelFactory.CreateKernel();
        public static readonly IPersonService personService = Kernel.Get<IPersonService>();
    }
}
