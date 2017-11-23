using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WarehousePhysicalAPI.Domain;
using WarehousePhysicalAPI.Services;

namespace WarehousePhysicalAPI
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // put bindings here
            kernel.Bind<IEFDbRepository>().To<EFRepository>();
            kernel.Bind<IExcelFileService>().To<ExcelFileService>();
            kernel.Bind<IItileRepository>().To<ItileRepository>();
        }
    }
}