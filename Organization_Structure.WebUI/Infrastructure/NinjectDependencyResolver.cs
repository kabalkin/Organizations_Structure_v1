using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Organization_Structure.Domain.Abstract;
using Organization_Structure.Domain.Concrete;
using Organization_Structure.WebUI.Infrastructure.Abstract;
using Organization_Structure.WebUI.Infrastructure.Concrete;

namespace GameStore.WebUI.Infrastructure
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
			kernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>();
			kernel.Bind<IGroupRepository>().To<EFGroupRepository>();
			kernel.Bind<IDepartmentRepository>().To<EFDepartmentRepository>();
			kernel.Bind<IPositionRepository>().To<EFPositionsRepository>();
			kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
		}
	}
}