# IP2Location.io .NET SDK
[![NuGet Version](https://img.shields.io/nuget/v/IP2Location.io)](https://www.nuget.org/packages/IP2Location.io)
[![NuGet Downloads](https://img.shields.io/nuget/dt/IP2Location.io)](https://www.nuget.org/packages/IP2Location.io)


This .NET library enables user to query for an enriched data set, such as country, region, city, latitude & longitude, ZIP code, time zone, ASN, ISP, domain, net speed, IDD code, area code, weather station data, MNC, MCC, mobile brand, elevation, usage type, address type, advertisement category, fraud score and proxy data with an IP address. It supports both IPv4 and IPv6 address lookup.

In addition, this module provides WHOIS lookup api that helps users to obtain domain information, WHOIS record, by using a domain name. The WHOIS API returns a comprehensive WHOIS data such as creation date, updated date, expiration date, domain age, the contact information of the registrant, mailing address, phone number, email address, nameservers the domain is using and much more.

There is also a Hosted Domain API that allowing users to get the list of hosted domain names by IP address in real time. The REST API supports both IPv4 and IPv6 address lookup.

This module requires API key to function. You may sign up for a free API key at https://www.ip2location.io/pricing.

Developer Documentation
=====================

To learn more about installation, usage, and code examples, please visit the developer documentation at [https://ip2location-io-dotnet.readthedocs.io/en/latest/index.html](https://ip2location-io-dotnet.readthedocs.io/en/latest/index.html).


Pre-requisite
=============
Microsoft Visual Studio 2022 or later.


Installation
============
https://www.nuget.org/packages/IP2Location.io


Usage Example
=============

Refer to the [Sample Code section](https://ip2location-io-dotnet.readthedocs.io/en/latest/quickstart.html#sample-codes)


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
|time_zone_info.abbreviation|string|The time zone abbreviation of the Olson time zone, for example EST and EEST.|
|time_zone_info.dst_start_date|string|The date (UTC) of Daylight Saving Time (DST) begins.|
|time_zone_info.dst_end_date|string|The date (UTC) of Daylight Saving Time (DST) ends.|
|time_zone_info.sunrise|string|Time of sunrise. (hh:mm format in local time, i.e, 07:47)|
|time_zone_info.sunset|string|Time of sunset. (hh:mm format in local time, i.e 19:50)|
|geotargeting.metro|string|Metro code based on zip/postal code.|
|ads_category|string|The domain category code based on IAB Tech Lab Content Taxonomy.|
|ads_category_name|string|The domain category based on IAB Tech Lab Content Taxonomy. These categories are comprised of Tier-1 and Tier-2 (if available) level categories widely used in services like advertising, Internet security and filtering appliances.|
|is_proxy|boolean|Whether is a proxy or not.|
|fraud_score|integer|Potential risk score (0 - 99) associated with IP address. A higher IP2Proxy Fraud Score indicates a greater likelihood of fraudulent activity and a lower reputation.|
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
|proxy.is_bogon|boolean|Unassigned or illegitimate IP addresses announced via BGP.|
|proxy.is_consumer_privacy_network|boolean|Consumer Privacy Networks.|
|proxy.is_enterprise_private_network|boolean|Enterprise Private Networks.|

```json
{
    "ip": "8.8.8.8",
    "country_code": "US",
    "country_name": "United States of America",
    "region_name": "California",
    "district": "Santa Clara County",
    "city_name": "Mountain View",
    "latitude": 37.38605,
    "longitude": -122.08385,
    "zip_code": "94035",
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
    "ads_category": "IAB19-11",
    "ads_category_name": "Data Centers",
    "continent": {
        "name": "North America",
        "code": "NA",
        "hemisphere": [
            "north",
            "west"
        ],
        "translation": {
            "lang": "en",
            "value": "North America"
        }
    },
    "country": {
        "name": "United States of America",
        "alpha3_code": "USA",
        "numeric_code": 840,
        "demonym": "Americans",
        "flag": "https://cdn.ip2location.io/assets/img/flags/us.png",
        "capital": "Washington, D.C.",
        "total_area": 9826675,
        "population": 339665118,
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
            "lang": "en",
            "value": "United States of America"
        }
    },
    "region": {
        "name": "California",
        "code": "US-CA",
        "translation": {
            "lang": "en",
            "value": "California"
        }
    },
    "city": {
        "name": "Mountain View",
        "translation": {
            "lang": "en",
            "value": "Mountain View"
        }
    },
    "time_zone_info": {
        "olson": "America/Los_Angeles",
        "current_time": "2025-04-14T23:13:23-07:00",
        "gmt_offset": -25200,
        "is_dst": true,
        "sunrise": "06:31",
        "sunset": "19:45"
    },
    "geotargeting": {
        "metro": "807"
    },
    "is_proxy": false,
    "fraud_score": 0,
    "proxy": {
        "last_seen": 14,
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
        "is_consumer_privacy_network": false,
        "is_enterprise_private_network": false,
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


### IP Hosted Domains Lookup function
| Parameter | Type | Description |
|---|---|---|
|ip|string|IP address.|
|total_domains|integer|Total number of hosted domains found.|
|page|integer|Current lookup page.|
|per_page|integer|Number of domains displayed in the page.|
|total_pages|integer|Total pages of the hosted domains.|
|domains|array|Hosted domains of the lookup IP Address.|

```json
{
  "ip": "8.8.8.8",
  "total_domains": 3858,
  "page": 1,
  "per_page": 100,
  "total_pages": 39,
  "domains": [
    "000180.top",
    "00100tet.xyz",
    "001hash.vip",
    "002hash.com",
    "0050500.xyz",
    "007515.com",
    "023mm.net",
    "023mt.net",
    "023sn.net",
    "031000.xyz",
    "0515smw.com",
    "058637.com",
    "0798907.xyz",
    "07capital.com",
    "07osrs.com",
    "07sh2wv.bar",
    "0857.site",
    "0931seo.com",
    "0lzh.com",
    "0x4f.com",
    "0x57696c6c.com",
    "0xb055.com",
    "1-189tais.com",
    "10askfcwebkvh.top",
    "1102halfhowehbao1.com",
    "1102hdfkeuwuhfubao2.com",
    "1102hdukefjkf2.com",
    "1102sdbkwuoubao3.com",
    "11107hdkjhguk.com",
    "111km.xyz",
    "1130kfhuhw.com",
    "11eqlhon.top",
    "1206m.site",
    "125ap.com",
    "12la21wn31da40le6.com",
    "12safhoie.top",
    "12tivi.com",
    "1333limited.com",
    "1333yyh.com",
    "135493.com",
    "136668.xyz",
    "13shkuwq.top",
    "142937440.site",
    "144888.xyz",
    "14whoduhw.top",
    "1562yjargm.xyz",
    "15sdkwb.top",
    "167853.xyz",
    "168.one",
    "168km.xyz",
    "16uhwfuhe.cyou",
    "176274.com",
    "17diqwehfoi.cyou",
    "17jule.com",
    "18uhefoh.cyou",
    "191095211.xyz",
    "19931006.xyz",
    "19g.vip",
    "19wuji.cyou",
    "1huofhoehfogakfwqqq.com",
    "1ine1.com",
    "1master-fitness.com",
    "1rf3k.com",
    "1s1s.app",
    "1visualizer.app",
    "200250.xyz",
    "20070217.xyz",
    "20088888.xyz",
    "20230406.mov",
    "205566.com",
    "205artemisbet.com",
    "20iiij.cyou",
    "21107ahsfukhweo.com",
    "21hodheoh.cyou",
    "22bahman.space",
    "22howhw.cyou",
    "231q.top",
    "234n.top",
    "236j.top",
    "23hw.cyou",
    "24asfbkhb.cyou",
    "24ihhcorp.com",
    "25dgfu.cyou",
    "26asfhku.cyou",
    "277210.shop",
    "27adfljn.cyou",
    "28dshkf.cyou",
    "29583.biz",
    "29dakfb.cyou",
    "2ashdowehofhweohfo.com",
    "2c.com",
    "2qdrap.com",
    "2s1c.com",
    "304065117.xyz",
    "30fwhdfkb.cyou",
    "3101r.space",
    "31107abskjfbekb.com",
    "315sx.com",
    "31dfhkjsdb.cyou",
    "325965.com"
  ]
}
```

LICENCE
=====================
See the LICENSE file.
