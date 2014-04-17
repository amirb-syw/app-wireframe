using System.Web.Mvc;
using Platform.Client.Configuration;
using SywApplicationWireframe.Common.Filters;
using SywApplicationWireframe.Domain.Auth;
using SywApplicationWireframe.Domain.Context;
using SywApplicationWireframe.Web.UI.Filters;

namespace SywApplicationWireframe.Web.UI.App_Start
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			var container = IoCActivator.Container;
			
			filters.Add(new HandleErrorAttribute());
			filters.Add(new TokenExtractingFilter(container.Resolve<IPlatformTokenDistributer>()));
			filters.Add(new TokenPersistenceFilter(container.Resolve<IApplicationSettings>()));
			filters.Add(new DefaultExceptionHandlingFilter(container.Resolve<IExceptionHandler>()));
			filters.Add(new RequestDataExtractorFilter(container.Resolve<IRequestContextProvider>(),
														container.Resolve<IRequestContentProvider>(),
														container.Resolve<ILoggingContext>()));
		}
	}
}