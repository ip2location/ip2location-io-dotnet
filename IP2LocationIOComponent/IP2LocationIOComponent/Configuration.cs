using System;
using System.Reflection;

namespace IP2LocationIOComponent
{
	public class Configuration
	{
		private Version version;
		private string apikey = "";

		// Description: Returns the assembly version
		public string Version
		{
			get
			{
				version = Assembly.GetExecutingAssembly().GetName().Version;
				return version.Major + "." + version.Minor + "." + version.Build;
			}

		}

		// Description: Get or set the IP2Location.io API key
		public string ApiKey
		{
			get
			{
				return apikey;
			}
			set
			{
				apikey = value;
			}
		}
	}
}
