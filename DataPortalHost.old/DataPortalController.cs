using System;
using System.Net.Http;
using System.Threading.Tasks;
using Csla.Server.Hosts;

namespace DataPortalHost {
	public sealed class DataPortalController : HttpPortalController {
		public override Task<HttpResponseMessage> PostAsync(string operation) {
			try {
				return base.PostAsync(operation);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				throw;
			}
		}
	}
}