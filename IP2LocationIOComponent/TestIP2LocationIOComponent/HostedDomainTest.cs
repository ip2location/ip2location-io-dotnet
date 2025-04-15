using IP2LocationIOComponent;

namespace TestIP2LocationIOComponent
{
	[TestClass]
	public class HostedDomainTest
	{
		[TestMethod]
		public void TestInvalidAPIKey()
		{
			Configuration config = new()
			{
				ApiKey = ""
			};

			HostedDomain HD = new(config);
			var MyTask = HD.Lookup("8.8.8.8"); // async API call

			try
			{
				var MyObj = MyTask.Result;
			}
			catch (Exception ex)
			{
				Assert.AreEqual("One or more errors occurred. (Missing parameter.)", ex.Message);
			}
		}
	}
}