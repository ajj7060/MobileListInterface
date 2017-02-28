using System;
using System.Web.Http;
using Csla;

namespace DataPortalHost {
	public class Global : System.Web.HttpApplication {
		protected void Application_Start(object sender, EventArgs e) {
			ApplicationContext.AuthenticationType = "Windows";

			GlobalConfiguration.Configure(
				config => {
					config.MapHttpAttributeRoutes();

					config.Routes.MapHttpRoute(
						"DataPortalApi",
						"api/dataportal",
						new { controller = "DataPortal" }
					);
				});
		}

		protected void Session_Start(object sender, EventArgs e) {

		}

		protected void Application_BeginRequest(object sender, EventArgs e) {

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) {

		}

		protected void Application_Error(object sender, EventArgs e) {

		}

		protected void Session_End(object sender, EventArgs e) {

		}

		protected void Application_End(object sender, EventArgs e) {

		}
	}
}