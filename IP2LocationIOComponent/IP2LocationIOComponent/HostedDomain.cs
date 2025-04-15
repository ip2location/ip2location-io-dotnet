using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IP2LocationIOComponent
{
	public class HostedDomain
	{
		private const string BaseUrl = "https://domains.ip2whois.com/domains";
		private const string Source = "sdk-dotnet-iplio";
		private const string Format = "json";
		private const string Error = "HostedDomain lookup error.";
		private string url;
		private readonly Configuration configuration;
		static readonly HttpClient client = new HttpClient();

		public HostedDomain(Configuration config)
		{
			configuration = config;
		}

		// Description: Lookup given IP address for hosted domains
		public async Task<JObject> Lookup(string ip, int page = 1)
		{
			try
			{
				url = BaseUrl + "?format=" + Format + "&source=" + Source + "&source_version=" + configuration.Version + "&key=" + configuration.ApiKey + "&page=" + page + "&ip=" + WebUtility.UrlEncode(ip ?? "");
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.StatusCode == HttpStatusCode.OK)
				{
					string rawjson = await response.Content.ReadAsStringAsync();
					JObject results = JsonConvert.DeserializeObject<JObject>(rawjson);
					return results;
				}
				else if ((response.StatusCode == HttpStatusCode.Unauthorized) || (response.StatusCode == HttpStatusCode.BadRequest))
				{
					string rawjson = await response.Content.ReadAsStringAsync();
					if (rawjson.Contains("error_message"))
					{
						JObject results = JsonConvert.DeserializeObject<JObject>(rawjson);
						throw new Exception(results["error"]["error_message"].ToString());
					}
					throw new Exception(Error);
				}
			}
			catch (HttpRequestException ex)
			{
				throw new Exception(ex.Message);
			}
			throw new Exception(Error);
		}
	}
}
