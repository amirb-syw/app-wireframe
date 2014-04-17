using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Http;
using System.Web.Mvc;
using SywApplicationWireframe.Common.Ioc;
using SywApplicationWireframe.Web.UI.App_Start;

[assembly: WebActivator.PreApplicationStartMethod(typeof (IoCActivator), "Start")]

namespace SywApplicationWireframe.Web.UI.App_Start
{
	public static class IoCActivator
	{
		public static IWindsorContainer Container { get; private set; }
		
		public static void Start()
		{
			var container = new WindsorContainer()
				.Install(FromAssembly.This())
				.Install(FromAssembly.Containing<DomainInstaller>());

			Container = container;

			var mvcControllerFactory = new WindsorControllerFactory(container.Kernel);
			ControllerBuilder.Current.SetControllerFactory(mvcControllerFactory);
		}
	}
}