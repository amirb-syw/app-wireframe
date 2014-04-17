using System.Web.Mvc;

namespace SywApplicationWireframe.Web.UI.Views.Shared
{
	public class LoginController : Controller
	{
		[RequireHttps]
		public ActionResult Index()
		{
			return View();
		}
	}
}