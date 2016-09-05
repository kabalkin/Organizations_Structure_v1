using System;
using System.Linq;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Organization_Structure.Domain.Concrete;
using Organization_Structure.Domain.Entities;
using Organization_Structure.WebUI;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Organization_Structure.WebUI
{
	public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);

				
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			System.Web.Mvc.DependencyResolver.SetResolver(new
			GameStore.WebUI.Infrastructure.NinjectDependencyResolver(kernel));

			AddDefaultData();
		}

		private static void AddDefaultData()
		{
			EFDbContext context = new EFDbContext();
			if (context.Employees.Count() == 0 && context.Departments.Count() == 0 &&
				context.Groups.Count() == 0 && context.Managements.Count() == 0 &&
				context.Positions.Count() == 0)
			{
				context.Positions.Add(new Position { Id = 1, Description = "Programmer" });
				context.Positions.Add(new Position { Id = 2, Description = "Tester" });
				context.Managements.Add(new Management { Id = 1, Title = "Management 1" });
				context.Departments.Add(new Department { Id = 1, ManagementId = 1, Title = "Department 1" });
				context.Departments.Add(new Department { Id = 2, ManagementId = 1, Title = "Department 2" });
				context.Departments.Add(new Department { Id = 3, ManagementId = 1, Title = "Department 3" });
				context.Groups.Add(new Group { Id = 1, DepartmentId = 1, Title = "Group 11" });
				context.Groups.Add(new Group { Id = 2, DepartmentId = 1, Title = "Group 12" });
				context.Groups.Add(new Group { Id = 3, DepartmentId = 1, Title = "Group 13" });
				context.Groups.Add(new Group { Id = 4, DepartmentId = 2, Title = "Group 21" });
				context.Groups.Add(new Group { Id = 5, DepartmentId = 2, Title = "Group 22" });
				context.Groups.Add(new Group { Id = 6, DepartmentId = 3, Title = "Group 31" });
				context.Employees.Add(new Employee { Id = 1, GroupID = 1, FIO = "Petrov", PositionId = 1 });
				context.Employees.Add(new Employee { Id = 2, GroupID = 1, FIO = "Ivanov", PositionId = 1 });
				context.Employees.Add(new Employee { Id = 3, GroupID = 1, FIO = "Sidorov", PositionId = 1 });
				context.Employees.Add(new Employee { Id = 4, GroupID = 2, FIO = "Sharov", PositionId = 2 });
				context.Employees.Add(new Employee { Id = 5, GroupID = 2, FIO = "Cherenkov", PositionId = 2 });
				context.Employees.Add(new Employee { Id = 6, GroupID = 3, FIO = "Pavluchenkov", PositionId = 1 });
				context.Employees.Add(new Employee { Id = 7, GroupID = 4, FIO = "Solomonov", PositionId = 2 });
				context.Employees.Add(new Employee { Id = 8, GroupID = 5, FIO = "Kuznecov", PositionId = 1 });
				context.Employees.Add(new Employee { Id = 9, GroupID = 5, FIO = "Test1", PositionId = 2 });
				context.Employees.Add(new Employee { Id = 10, GroupID = 5, FIO = "Test2", PositionId = 1 });
				context.Employees.Add(new Employee { Id = 11, GroupID = 5, FIO = "Test3", PositionId = 1 });
				context.Employees.Add(new Employee { Id = 12, GroupID = 5, FIO = "Test4", PositionId = 2 });
				context.Employees.Add(new Employee { Id = 13, GroupID = 5, FIO = "Test5", PositionId = 2 });
				context.Employees.Add(new Employee { Id = 14, GroupID = 6, FIO = "Test6", PositionId = 1 });
				context.SaveChanges();
			}
		}
	}
}
