using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IP2LocationIOComponent
{
	public class IPGeolocation
	{
		private const string BaseUrl = "https://api.ip2location.io/";
		private const string Source = "sdk-dotnet-iplio";
		private const string Format = "json";
		private const string Error = "IPGeolocation lookup error.";
		private string url;
		private readonly Configuration configuration;
		static readonly HttpClient client = new HttpClient();

		public IPGeolocation(Configuration config)
		{
			configuration = config;
		}

		// Description: Lookup given IP address for an enriched data set
		public async Task<JObject> Lookup(string ip, string language = "")
		{
			try
			{
				url = BaseUrl + "?format=" + Format + "&source=" + Source + "&source_version=" + configuration.Version + "&key=" + configuration.ApiKey + "&lang=" + WebUtility.UrlEncode(language ?? "") + "&ip=" + WebUtility.UrlEncode(ip ?? "");
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
