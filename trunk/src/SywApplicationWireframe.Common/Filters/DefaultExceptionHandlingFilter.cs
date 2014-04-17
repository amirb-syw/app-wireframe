using System.Web.Mvc;

namespace SywApplicationWireframe.Common.Filters
{
	public class DefaultExceptionHandlingFilter : IExceptionFilter
	{
		private readonly IExceptionHandler _exceptionHandler;

		public DefaultExceptionHandlingFilter(IExceptionHandler exceptionHandler)
		{
			_exceptionHandler = exceptionHandler;
		}

		public void OnException(ExceptionContext filterContext)
		{
			_exceptionHandler.Handle(filterContext);
		}
	}
}