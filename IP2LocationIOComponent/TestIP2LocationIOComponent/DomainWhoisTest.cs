using IP2LocationIOComponent;

namespace TestIP2LocationIOComponent
{
	[TestClass]
	public class DomainWhoisTest
	{
		[TestMethod]
		public void TestInvalidAPIKey()
		{
			Configuration config = new()
			{
				ApiKey = ""
			};

			DomainWhois Whois = new(config);
			var MyTask = Whois.Lookup("example.c"); // async API call

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