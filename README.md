IP2Location.io .NET SDK
=======================
This .NET library enables user to query for an enriched data set, such as country, region, city, latitude & longitude, ZIP code, time zone, ASN, ISP, domain, net speed, IDD code, area code, weather station data, MNC, MCC, mobile brand, elevation, usage type, address type, advertisement category and proxy data with an IP address. It supports both IPv4 and IPv6 address lookup.

In addition, this module provides WHOIS lookup api that helps users to obtain domain information, WHOIS record, by using a domain name. The WHOIS API returns a comprehensive WHOIS data such as creation date, updated date, expiration date, domain age, the contact information of the registrant, mailing address, phone number, email address, nameservers the domain is using and much more.

This module requires API key to function. You may sign up for a free API key at https://www.ip2location.io/pricing.


Pre-requisite
=============
Microsoft Visual Studio 2022 or later.


Installation
============
https://www.nuget.org/packages/IP2Location.io


Usage Example
=============
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


Response Parameter
==================
### IP Geolocation Lookup function
| Parameter | Type | Description |
|---|---|---|
|ip|string|IP address.|
|country_code|string|Two-character country code based on ISO 3166.|
|country_name|string|Country name based on ISO 3166.|
|region_name|string|Region or state name.|
|city_name|string|City name.|
|latitude|double|City latitude. Defaults to capital city latitude if city is unknown.|
|longitude|double|City longitude. Defaults to capital city longitude if city is unknown.|
|zip_code|string|ZIP/Postal code.|
|time_zone|string|UTC time zone (with DST supported).|
|asn|string|Autonomous system number (ASN).|
|as|string|Autonomous system (AS) name.|
|isp|string|Internet Service Provider or company's name.|
|domain|string|Internet domain name associated with IP address range.|
|net_speed|string|Internet connection type. DIAL = dial-up, DSL = broadband/cable/fiber/mobile, COMP = company/T1|
|idd_code|string|The IDD prefix to call the city from another country.|
|area_code|string|A varying length number assigned to geographic areas for calls between cities.|
|weather_station_code|string|The special code to identify the nearest weather observation station.|
|weather_station_name|string|The name of the nearest weather observation station.|
|mcc|string|Mobile Country Codes (MCC) as defined in ITU E.212 for use in identifying mobile stations in wireless telephone networks, particularly GSM and UMTS networks.|
|mnc|string|Mobile Network Code (MNC) is used in combination with a Mobile Country Code (MCC) to uniquely identify a mobile phone operator or carrier.|
|mobile_brand|string|Commercial brand associated with the mobile carrier.|
|elevation|integer|Average height of city above sea level in meters (m).|
|usage_type|string|Usage type classification of ISP or company.|
|address_type|string|IP address types as defined in Internet Protocol version 4 (IPv4) and Internet Protocol version 6 (IPv6).|
|continent.name|string|Continent name.|
|continent.code|string|Two-character continent code.|
|continent.hemisphere|array|The hemisphere of where the country located. The data in array format with first item indicates (north/south) hemisphere and second item indicates (east/west) hemisphere information.|
|continent.translation|object|Translation data based on the given lang code.|
|district|string|District or county name.|
|country.name|string|Country name based on ISO 3166.|
|country.alpha3_code|string|Three-character country code based on ISO 3166.|
|country.numeric_code|string|Three-character country numeric code based on ISO 3166.|
|country.demonym|string|Native of the country.|
|country.flag|string|URL of the country flag image.|
|country.capital|string|Capital of the country.|
|country.total_area|integer|Total area in km2.|
|country.population|integer|Population of the country.|
|country.currency|object|Currency of the country.|
|country.language|object|Language of the country.|
|country.tld|string|Country-Code Top-Level Domain.|
|country.translation|object|Translation data based on the given lang code.|
|region.name|string|Region or state name.|
|region.code|string|ISO3166-2 code.|
|region.translation|object|Translation data based on the given lang code.|
|city.name|string| City name.|
|city.translation|object|Translation data based on the given lang code.|
|time_zone_info.olson|string|Time zone in Olson format.|
|time_zone_info.current_time|string|Current time in ISO 8601 format.|
|time_zone_info.gmt_offset|integer|GMT offset value in seconds.|
|time_zone_info.is_dst|boolean|Indicate if the time zone value is in DST.|
|time_zone_info.sunrise|string|Time of sunrise. (hh:mm format in local time, i.e, 07:47)|
|time_zone_info.sunset|string|Time of sunset. (hh:mm format in local time, i.e 19:50)|
|geotargeting.metro|string|Metro code based on zip/postal code.|
|ads_category|string|The domain category code based on IAB Tech Lab Content Taxonomy.|
|ads_category_name|string|The domain category based on IAB Tech Lab Content Taxonomy. These categories are comprised of Tier-1 and Tier-2 (if available) level categories widely used in services like advertising, Internet security and filtering appliances.|
|is_proxy|boolean|Whether is a proxy or not.|
|proxy.last_seen|integer|Proxy last seen in days.|
|proxy.proxy_type|string|Type of proxy.|
|proxy.threat|string|Security threat reported.|
|proxy.provider|string|Name of VPN provider if available.|
|proxy.is_vpn|boolean|Anonymizing VPN services.|
|proxy.is_tor|boolean|Tor Exit Nodes.|
|proxy.is_data_center|boolean|Hosting Provider, Data Center or Content Delivery Network.|
|proxy.is_public_proxy|boolean|Public Proxies.|
|proxy.is_web_proxy|boolean|Web Proxies.|
|proxy.is_web_crawler|boolean|Search Engine Robots.|
|proxy.is_residential_proxy|boolean|Residential proxies.|
|proxy.is_spammer|boolean|Email and forum spammers.|
|proxy.is_scanner|boolean|Network security scanners.|
|proxy.is_botnet|boolean|Malware infected devices.|
|proxy.is_consumer_privacy_network|boolean|Consumer Privacy Networks.|
|proxy.is_enterprise_private_network|boolean|Enterprise Private Networks.|

```json
{
  "ip": "8.8.8.8",
  "country_code": "US",
  "country_name": "United States of America",
  "region_name": "California",
  "city_name": "Mountain View",
  "latitude": 37.405992,
  "longitude": -122.078515,
  "zip_code": "94043",
  "time_zone": "-07:00",
  "asn": "15169",
  "as": "Google LLC",
  "isp": "Google LLC",
  "domain": "google.com",
  "net_speed": "T1",
  "idd_code": "1",
  "area_code": "650",
  "weather_station_code": "USCA0746",
  "weather_station_name": "Mountain View",
  "mcc": "-",
  "mnc": "-",
  "mobile_brand": "-",
  "elevation": 32,
  "usage_type": "DCH",
  "address_type": "Anycast",
  "continent": {
    "name": "North America",
    "code": "NA",
    "hemisphere": [
      "north",
      "west"
    ],
    "translation": {
      "lang": "es",
      "value": "Norteamérica"
    }
  },
  "district": "Santa Clara County",
  "country": {
    "name": "United States of America",
    "alpha3_code": "USA",
    "numeric_code": 840,
    "demonym": "Americans",
    "flag": "https://cdn.ip2location.io/assets/img/flags/us.png",
    "capital": "Washington, D.C.",
    "total_area": 9826675,
    "population": 331002651,
    "currency": {
      "code": "USD",
      "name": "United States Dollar",
      "symbol": "$"
    },
    "language": {
      "code": "EN",
      "name": "English"
    },
    "tld": "us",
    "translation": {
      "lang": "es",
      "value": "Estados Unidos de América (los)"
    }
  },
  "region": {
    "name": "California",
    "code": "US-CA",
    "translation": {
      "lang": "es",
      "value": "California"
    }
  },
  "city": {
    "name": "Mountain View",
    "translation": {
      "lang": null,
      "value": null
    }
  },
  "time_zone_info": {
    "olson": "America/Los_Angeles",
    "current_time": "2023-09-03T18:21:13-07:00",
    "gmt_offset": -25200,
    "is_dst": true,
    "sunrise": "06:41",
    "sunset": "19:33"
  },
  "geotargeting": {
    "metro": "807"
  },
  "ads_category": "IAB19-11",
  "ads_category_name": "Data Centers",
  "is_proxy": false,
  "proxy": {
    "last_seen": 3,
    "proxy_type": "DCH",
    "threat": "-",
    "provider": "-",
    "is_vpn": false,
    "is_tor": false,
    "is_data_center": true,
    "is_public_proxy": false,
    "is_web_proxy": false,
    "is_web_crawler": false,
    "is_residential_proxy": false,
    "is_spammer": false,
    "is_scanner": false,
    "is_botnet": false
  }
}
```


### Domain WHOIS Lookup function
| Parameter | Type | Description |
|---|---|---|
|domain|string|Domain name.|
|domain_id|string|Domain name ID.|
|status|string|Domain name status.|
|create_date|string|Domain name creation date.|
|update_date|string|Domain name updated date.|
|expire_date|string|Domain name expiration date.|
|domain_age|integer|Domain name age in day(s).|
|whois_server|string|WHOIS server name.|
|registrar.iana_id|string|Registrar IANA ID.|
|registrar.name|string|Registrar name.|
|registrar.url|string|Registrar URL.|
|registrant.name|string|Registrant name.|
|registrant.organization|string|Registrant organization.|
|registrant.street_address|string|Registrant street address.|
|registrant.city|string|Registrant city.|
|registrant.region|string|Registrant region.|
|registrant.zip_code|string|Registrant ZIP Code.|
|registrant.country|string|Registrant country.|
|registrant.phone|string|Registrant phone number.|
|registrant.fax|string|Registrant fax number.|
|registrant.email|string|Registrant email address.|
|admin.name|string|Admin name.|
|admin.organization|string|Admin organization.|
|admin.street_address|string|Admin street address.|
|admin.city|string|Admin city.|
|admin.region|string|Admin region.|
|admin.zip_code|string|Admin ZIP Code.|
|admin.country|string|Admin country.|
|admin.phone|string|Admin phone number.|
|admin.fax|string|Admin fax number.|
|admin.email|string|Admin email address.|
|tech.name|string|Tech name.|
|tech.organization|string|Tech organization.|
|tech.street_address|string|Tech street address.|
|tech.city|string|Tech city.|
|tech.region|string|Tech region.|
|tech.zip_code|string|Tech ZIP Code.|
|tech.country|string|Tech country.|
|tech.phone|string|Tech phone number.|
|tech.fax|string|Tech fax number.|
|tech.email|string|Tech email address.|
|billing.name|string|Billing name.|
|billing.organization|string|Billing organization.|
|billing.street_address|string|Billing street address.|
|billing.city|string|Billing city.|
|billing.region|string|Billing region.|
|billing.zip_code|string|Billing ZIP Code.|
|billing.country|string|Billing country.|
|billing.phone|string|Billing phone number.|
|billing.fax|string|Billing fax number.|
|billing.email|string|Billing email address.|
|nameservers|array|Name servers|

```json
{
	"domain": "locaproxy.com",
	"domain_id": "1710914405_DOMAIN_COM-VRSN",
	"status": "clientTransferProhibited https://icann.org/epp#clientTransferProhibited",
	"create_date": "2012-04-03T02:34:32Z",
	"update_date": "2021-12-03T02:54:57Z",
	"expire_date": "2024-04-03T02:34:32Z",
	"domain_age": 4055,
	"whois_server": "whois.godaddy.com",
	"registrar": {
		"iana_id": "146",
		"name": "GoDaddy.com, LLC",
		"url": "https://www.godaddy.com"
	},
	"registrant": {
		"name": "Registration Private",
		"organization": "Domains By Proxy, LLC",
		"street_address": "DomainsByProxy.com",
		"city": "Tempe",
		"region": "Arizona",
		"zip_code": "85284",
		"country": "US",
		"phone": "+1.4806242599",
		"fax": "+1.4806242598",
		"email": "Select Contact Domain Holder link at https://www.godaddy.com/whois/results.aspx?domain=LOCAPROXY.COM"
	},
	"admin": {
		"name": "Registration Private",
		"organization": "Domains By Proxy, LLC",
		"street_address": "DomainsByProxy.com",
		"city": "Tempe",
		"region": "Arizona",
		"zip_code": "85284",
		"country": "US",
		"phone": "+1.4806242599",
		"fax": "+1.4806242598",
		"email": "Select Contact Domain Holder link at https://www.godaddy.com/whois/results.aspx?domain=LOCAPROXY.COM"
	},
	"tech": {
		"name": "Registration Private",
		"organization": "Domains By Proxy, LLC",
		"street_address": "DomainsByProxy.com",
		"city": "Tempe",
		"region": "Arizona",
		"zip_code": "85284",
		"country": "US",
		"phone": "+1.4806242599",
		"fax": "+1.4806242598",
		"email": "Select Contact Domain Holder link at https://www.godaddy.com/whois/results.aspx?domain=LOCAPROXY.COM"
	},
	"billing": {
		"name": "",
		"organization": "",
		"street_address": "",
		"city": "",
		"region": "",
		"zip_code": "",
		"country": "",
		"phone": "",
		"fax": "",
		"email": ""
	},
	"nameservers": [
		"vera.ns.cloudflare.com",
		"walt.ns.cloudflare.com"
	]
}
```


LICENCE
=====================
See the LICENSE file.
