using System;
using Library;

namespace CslaBusinessListInterface {
	internal class Program {
		public static void Main(string[] args) {
			DoCall();

			Console.ReadLine();
		}

		private static async void DoCall() {
			try {
				var myBo = await MyRootObject.GetMyRootObjectAsync();

				foreach (var child in myBo.ChildObjects) {
					Console.WriteLine($"Name = {child.Name}, Value = {child.Value}");
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}
}
