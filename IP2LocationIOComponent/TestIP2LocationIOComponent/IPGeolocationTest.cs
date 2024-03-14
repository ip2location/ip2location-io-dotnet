using IP2LocationIOComponent;

namespace TestIP2LocationIOComponent
{
	[TestClass]
	public class IPGeolocationTest
	{
		[TestMethod]
		public void TestInvalidAPIKey()
		{
			Configuration config = new()
			{
				ApiKey = ""
			};

			IPGeolocation IPL = new(config);
			var MyTask = IPL.Lookup("8.8.8.8"); // async API call

			try
			{
				var MyObj = MyTask.Result;
			}
			catch (Exception ex)
			{
				Assert.AreEqual("One or more errors occurred. (Invalid API key or insufficient credit.)", ex.Message);
			}
		}
	}
}