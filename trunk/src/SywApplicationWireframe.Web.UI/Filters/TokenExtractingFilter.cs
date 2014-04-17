using System.Web.Mvc;
using SywApplicationWireframe.Domain.Auth;

namespace SywApplicationWireframe.Web.UI.Filters
{
	public class TokenExtractingFilter : IAuthorizationFilter
	{
		private readonly IPlatformTokenDistributer _platformTokenDistributer;

		public TokenExtractingFilter(IPlatformTokenDistributer platformTokenDistributer)
		{
			_platformTokenDistributer = platformTokenDistributer;
		}

		public void OnAuthorization(AuthorizationContext filterContext)
		{
			var token = filterContext.HttpContext.Request.QueryString["token"];

			if (string.IsNullOrEmpty(token))
				return;

			_platformTokenDistributer.Distribute(token);
		}
	}
}