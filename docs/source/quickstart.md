# Quickstart

## Requirements

Microsoft Visual Studio 2022 or later.

## Installation

https://www.nuget.org/packages/IP2Location.io

## Sample Codes

### Lookup IP Address Geolocation Data
```C#
using Newtonsoft.Json;
using IP2LocationIOComponent;

// Configures IP2Location.io API key
Configuration Config = new()
{
	ApiKey = "YOUR_API_KEY"
};

IPGeolocation IPL = new(Config);
string IP = "8.8.8.8";
string Lang = "en"; // the language param is only available with Plus and Security plans

// Lookup ip address geolocation data
var MyTask = IPL.Lookup(IP, Lang); // async API call

try
{
	var MyObj = MyTask.Result;

	// pretty-print JSON
	Console.WriteLine(JsonConvert.SerializeObject(MyObj, Formatting.Indented));

	// individual fields
	Console.WriteLine("ip: {0}", MyObj["ip"]);
	Console.WriteLine("country_code: {0}", MyObj["country_code"]);
	Console.WriteLine("country_name: {0}", MyObj["country_name"]);
	Console.WriteLine("region_name: {0}", MyObj["region_name"]);
	Console.WriteLine("city_name: {0}", MyObj["city_name"]);
	Console.WriteLine("latitude: {0}", MyObj["latitude"]);
	Console.WriteLine("longitude: {0}", MyObj["longitude"]);
	Console.WriteLine("zip_code: {0}", MyObj["zip_code"]);
	Console.WriteLine("time_zone: {0}", MyObj["time_zone"]);
	Console.WriteLine("asn: {0}", MyObj["asn"]);
	Console.WriteLine("as: {0}", MyObj["as"]);
	if (MyObj["isp"] != null) Console.WriteLine("isp: {0}", MyObj["isp"]);
	if (MyObj["domain"] != null) Console.WriteLine("domain: {0}", MyObj["domain"]);
	if (MyObj["net_speed"] != null) Console.WriteLine("net_speed: {0}", MyObj["net_speed"]);
	if (MyObj["idd_code"] != null) Console.WriteLine("idd_code: {0}", MyObj["idd_code"]);
	if (MyObj["area_code"] != null) Console.WriteLine("area_code: {0}", MyObj["area_code"]);
	if (MyObj["weather_station_code"] != null) Console.WriteLine("weather_station_code: {0}", MyObj["weather_station_code"]);
	if (MyObj["weather_station_name"] != null) Console.WriteLine("weather_station_name: {0}", MyObj["weather_station_name"]);
	if (MyObj["mcc"] != null) Console.WriteLine("mcc: {0}", MyObj["mcc"]);
	if (MyObj["mnc"] != null) Console.WriteLine("mnc: {0}", MyObj["mnc"]);
	if (MyObj["mobile_brand"] != null) Console.WriteLine("mobile_brand: {0}", MyObj["mobile_brand"]);
	if (MyObj["elevation"] != null) Console.WriteLine("elevation: {0}", MyObj["elevation"]);
	if (MyObj["usage_type"] != null) Console.WriteLine("usage_type: {0}", MyObj["usage_type"]);
	if (MyObj["address_type"] != null) Console.WriteLine("address_type: {0}", MyObj["address_type"]);
	if (MyObj["district"] != null) Console.WriteLine("district: {0}", MyObj["district"]);
	if (MyObj["ads_category"] != null) Console.WriteLine("ads_category: {0}", MyObj["ads_category"]);
	if (MyObj["ads_category_name"] != null) Console.WriteLine("ads_category_name: {0}", MyObj["ads_category_name"]);
	Console.WriteLine("is_proxy: {0}", MyObj["is_proxy"]);
	if (MyObj["fraud_score"] != null) Console.WriteLine("fraud_score: {0}", MyObj["fraud_score"]);

	if (MyObj["as_info"] != null)
	{
		var Asinfo = MyObj["as_info"];
		Console.WriteLine("as_info => as_name: {0}", Asinfo["as_name"]);
		Console.WriteLine("as_info => as_number: {0}", Asinfo["as_number"]);
		Console.WriteLine("as_info => as_domain: {0}", Asinfo["as_domain"]);
		Console.WriteLine("as_info => as_cidr: {0}", Asinfo["as_cidr"]);
		Console.WriteLine("as_info => as_usage_type: {0}", Asinfo["as_usage_type"]);
	}

	if (MyObj["continent"] != null)
	{
		var Continent = MyObj["continent"];
		Console.WriteLine("continent => name: {0}", Continent["name"]);
		Console.WriteLine("continent => code: {0}", Continent["code"]);
		Console.WriteLine("continent => hemisphere: {0}", Continent["hemisphere"]);
		Console.WriteLine("continent => translation => lang: {0}", Continent["translation"]["lang"]);
		Console.WriteLine("continent => translation => value: {0}", Continent["translation"]["value"]);
	}

	if (MyObj["country"] != null)
	{
		var Country = MyObj["country"];
		Console.WriteLine("country => name: {0}", Country["name"]);
		Console.WriteLine("country => alpha3_code: {0}", Country["alpha3_code"]);
		Console.WriteLine("country => numeric_code: {0}", Country["numeric_code"]);
		Console.WriteLine("country => demonym: {0}", Country["demonym"]);
		Console.WriteLine("country => flag: {0}", Country["flag"]);
		Console.WriteLine("country => capital: {0}", Country["capital"]);
		Console.WriteLine("country => total_area: {0}", Country["total_area"]);
		Console.WriteLine("country => population: {0}", Country["population"]);
		Console.WriteLine("country => tld: {0}", Country["tld"]);

		Console.WriteLine("country => currency => code: {0}", Country["currency"]["code"]);
		Console.WriteLine("country => currency => name: {0}", Country["currency"]["name"]);
		Console.WriteLine("country => currency => symbol: {0}", Country["currency"]["symbol"]);

		Console.WriteLine("country => language => code: {0}", Country["language"]["code"]);
		Console.WriteLine("country => language => name: {0}", Country["language"]["name"]);

		Console.WriteLine("country => translation => lang: {0}", Country["translation"]["lang"]);
		Console.WriteLine("country => translation => value: {0}", Country["translation"]["value"]);
	}

	if (MyObj["region"] != null)
	{
		var Region = MyObj["region"];
		Console.WriteLine("region => name: {0}", Region["name"]);
		Console.WriteLine("region => code: {0}", Region["code"]);

		Console.WriteLine("region => translation => lang: {0}", Region["translation"]["lang"]);
		Console.WriteLine("region => translation => value: {0}", Region["translation"]["value"]);
	}

	if (MyObj["city"] != null)
	{
		var City = MyObj["city"];
		Console.WriteLine("city => name: {0}", City["name"]);

		Console.WriteLine("city => translation => lang: {0}", City["translation"]["lang"]);
		Console.WriteLine("city => translation => value: {0}", City["translation"]["value"]);
	}

	if (MyObj["time_zone_info"] != null)
	{
		var TimeZone = MyObj["time_zone_info"];
		Console.WriteLine("time_zone_info => olson: {0}", TimeZone["olson"]);
		Console.WriteLine("time_zone_info => current_time: {0}", TimeZone["current_time"]);
		Console.WriteLine("time_zone_info => gmt_offset: {0}", TimeZone["gmt_offset"]);
		Console.WriteLine("time_zone_info => is_dst: {0}", TimeZone["is_dst"]);
		Console.WriteLine("time_zone_info => abbreviation: {0}", TimeZone["abbreviation"]);
		Console.WriteLine("time_zone_info => dst_start_date: {0}", TimeZone["dst_start_date"]);
		Console.WriteLine("time_zone_info => dst_end_date: {0}", TimeZone["dst_end_date"]);
		Console.WriteLine("time_zone_info => sunrise: {0}", TimeZone["sunrise"]);
		Console.WriteLine("time_zone_info => sunset: {0}", TimeZone["sunset"]);
	}

	if (MyObj["geotargeting"] != null)
	{
		var GeoTarget = MyObj["geotargeting"];
		Console.WriteLine("geotargeting => metro: {0}", GeoTarget["metro"]);
	}

	if (MyObj["proxy"] != null)
	{
		var Proxy = MyObj["proxy"];
		Console.WriteLine("proxy => last_seen: {0}", Proxy["last_seen"]);
		Console.WriteLine("proxy => proxy_type: {0}", Proxy["proxy_type"]);
		Console.WriteLine("proxy => threat: {0}", Proxy["threat"]);
		Console.WriteLine("proxy => provider: {0}", Proxy["provider"]);
		Console.WriteLine("proxy => is_vpn: {0}", Proxy["is_vpn"]);
		Console.WriteLine("proxy => is_tor: {0}", Proxy["is_tor"]);
		Console.WriteLine("proxy => is_data_center: {0}", Proxy["is_data_center"]);
		Console.WriteLine("proxy => is_public_proxy: {0}", Proxy["is_public_proxy"]);
		Console.WriteLine("proxy => is_web_proxy: {0}", Proxy["is_web_proxy"]);
		Console.WriteLine("proxy => is_web_crawler: {0}", Proxy["is_web_crawler"]);
		Console.WriteLine("proxy => is_residential_proxy: {0}", Proxy["is_residential_proxy"]);
		Console.WriteLine("proxy => is_spammer: {0}", Proxy["is_spammer"]);
		Console.WriteLine("proxy => is_scanner: {0}", Proxy["is_scanner"]);
		Console.WriteLine("proxy => is_botnet: {0}", Proxy["is_botnet"]);
		Console.WriteLine("proxy => is_bogon: {0}", Proxy["is_bogon"]);
		Console.WriteLine("proxy => is_consumer_privacy_network: {0}", Proxy["is_consumer_privacy_network"]);
		Console.WriteLine("proxy => is_enterprise_private_network: {0}", Proxy["is_enterprise_private_network"]);
	}
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}

```


### Lookup Domain Information
```C#
using Newtonsoft.Json;
using IP2LocationIOComponent;

// Configures IP2Location.io API key
Configuration Config = new()
{
	ApiKey = "YOUR_API_KEY"
};

DomainWhois Whois = new(Config);
string domain = "example.com";

// Lookup domain information
var MyTask = Whois.Lookup(domain); // async API call

try
{
	var MyObj = MyTask.Result;

	// pretty-print JSON
	Console.WriteLine(JsonConvert.SerializeObject(MyObj, Formatting.Indented));

	// individual fields
	Console.WriteLine("domain: {0}", MyObj["domain"]);
	Console.WriteLine("domain_id: {0}", MyObj["domain_id"]);
	Console.WriteLine("status: {0}", MyObj["status"]);
	Console.WriteLine("create_date: {0}", MyObj["create_date"]);
	Console.WriteLine("update_date: {0}", MyObj["update_date"]);
	Console.WriteLine("expire_date: {0}", MyObj["expire_date"]);
	Console.WriteLine("domain_age: {0}", MyObj["domain_age"]);
	Console.WriteLine("whois_server: {0}", MyObj["whois_server"]);

	var Registrar = MyObj["registrar"];
	Console.WriteLine("registrar => iana_id: {0}", Registrar["iana_id"]);
	Console.WriteLine("registrar => name: {0}", Registrar["name"]);
	Console.WriteLine("registrar => url: {0}", Registrar["url"]);

	var Registrant = MyObj["registrant"];
	Console.WriteLine("registrant => name: {0}", Registrant["name"]);
	Console.WriteLine("registrant => organization: {0}", Registrant["organization"]);
	Console.WriteLine("registrant => street_address: {0}", Registrant["street_address"]);
	Console.WriteLine("registrant => city: {0}", Registrant["city"]);
	Console.WriteLine("registrant => region: {0}", Registrant["region"]);
	Console.WriteLine("registrant => zip_code: {0}", Registrant["zip_code"]);
	Console.WriteLine("registrant => country: {0}", Registrant["country"]);
	Console.WriteLine("registrant => phone: {0}", Registrant["phone"]);
	Console.WriteLine("registrant => fax: {0}", Registrant["fax"]);
	Console.WriteLine("registrant => email: {0}", Registrant["email"]);

	var Admin = MyObj["admin"];
	Console.WriteLine("admin => name: {0}", Admin["name"]);
	Console.WriteLine("admin => organization: {0}", Admin["organization"]);
	Console.WriteLine("admin => street_address: {0}", Admin["street_address"]);
	Console.WriteLine("admin => city: {0}", Admin["city"]);
	Console.WriteLine("admin => region: {0}", Admin["region"]);
	Console.WriteLine("admin => zip_code: {0}", Admin["zip_code"]);
	Console.WriteLine("admin => country: {0}", Admin["country"]);
	Console.WriteLine("admin => phone: {0}", Admin["phone"]);
	Console.WriteLine("admin => fax: {0}", Admin["fax"]);
	Console.WriteLine("admin => email: {0}", Admin["email"]);

	var Tech = MyObj["tech"];
	Console.WriteLine("tech => name: {0}", Tech["name"]);
	Console.WriteLine("tech => organization: {0}", Tech["organization"]);
	Console.WriteLine("tech => street_address: {0}", Tech["street_address"]);
	Console.WriteLine("tech => city: {0}", Tech["city"]);
	Console.WriteLine("tech => region: {0}", Tech["region"]);
	Console.WriteLine("tech => zip_code: {0}", Tech["zip_code"]);
	Console.WriteLine("tech => country: {0}", Tech["country"]);
	Console.WriteLine("tech => phone: {0}", Tech["phone"]);
	Console.WriteLine("tech => fax: {0}", Tech["fax"]);
	Console.WriteLine("tech => email: {0}", Tech["email"]);

	var Billing = MyObj["billing"];
	Console.WriteLine("billing => name: {0}", Billing["name"]);
	Console.WriteLine("billing => organization: {0}", Billing["organization"]);
	Console.WriteLine("billing => street_address: {0}", Billing["street_address"]);
	Console.WriteLine("billing => city: {0}", Billing["city"]);
	Console.WriteLine("billing => region: {0}", Billing["region"]);
	Console.WriteLine("billing => zip_code: {0}", Billing["zip_code"]);
	Console.WriteLine("billing => country: {0}", Billing["country"]);
	Console.WriteLine("billing => phone: {0}", Billing["phone"]);
	Console.WriteLine("billing => fax: {0}", Billing["fax"]);
	Console.WriteLine("billing => email: {0}", Billing["email"]);

	Console.WriteLine("nameservers: {0}", MyObj["nameservers"]);
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
```


### Convert Normal Text to Punycode
```C#
using IP2LocationIOComponent;

// Configures IP2Location.io API key
Configuration Config = new()
{
	ApiKey = "YOUR_API_KEY"
};

DomainWhois Whois = new(Config);

// Convert normal text to punycode
string domain = "täst.de";
Console.WriteLine(Whois.GetPunycode(domain));
```


### Convert Punycode to Normal Text
```C#
using IP2LocationIOComponent;

// Configures IP2Location.io API key
Configuration Config = new()
{
	ApiKey = "YOUR_API_KEY"
};

DomainWhois Whois = new(Config);

// Convert punycode to normal text
string domain = "xn--tst-qla.de";
Console.WriteLine(Whois.GetNormalText(domain));
```


### Get Domain Name
```C#
using IP2LocationIOComponent;

// Configures IP2Location.io API key
Configuration Config = new()
{
	ApiKey = "YOUR_API_KEY"
};

DomainWhois Whois = new(Config);

// Get domain name from URL
string url = "https://www.example.com/exe";
Console.WriteLine(Whois.GetDomainName(url));
```


### Get Domain Extension
```C#
using IP2LocationIOComponent;

// Configures IP2Location.io API key
Configuration Config = new()
{
	ApiKey = "YOUR_API_KEY"
};

DomainWhois Whois = new(Config);

// Get domain extension (gTLD or ccTLD) from URL or domain name
string str = "example.com";
Console.WriteLine(Whois.GetDomainExtension(str));
```


### Lookup IP Address Hosted Domain Data
```C#
using Newtonsoft.Json;
using IP2LocationIOComponent;

// Configures IP2Location.io API key
Configuration Config = new()
{
	ApiKey = "YOUR_API_KEY"
};

HostedDomain HD = new(Config);
string IP = "8.8.8.8";

// Lookup ip address hosted domain data
var MyTask = HD.Lookup(IP); // Optional: 2nd param which is the page of the result, defaults to the first page

try
{
	var MyObj = MyTask.Result;

	// pretty-print JSON
	Console.WriteLine(JsonConvert.SerializeObject(MyObj, Formatting.Indented));

	Console.WriteLine("ip: {0}", MyObj["ip"]);
	Console.WriteLine("total_domains: {0}", MyObj["total_domains"]);
	Console.WriteLine("page: {0}", MyObj["page"]);
	Console.WriteLine("per_page: {0}", MyObj["per_page"]);
	Console.WriteLine("total_pages: {0}", MyObj["total_pages"]);
	Console.WriteLine("domains: {0}", MyObj["domains"]);
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
```