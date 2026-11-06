# IP2Location.io .NET SDK — IP Geolocation, Domain WHOIS & Hosted Domain Lookup

[![NuGet Version](https://img.shields.io/nuget/v/IP2Location.io.svg)](https://www.nuget.org/packages/IP2Location.io)
[![NuGet Downloads](https://img.shields.io/nuget/dt/IP2Location.io.svg)](https://www.nuget.org/packages/IP2Location.io)

**IP2Location.io .NET SDK** is a C#/.NET library for retrieving **IPv4 and IPv6 geolocation, network and IP intelligence data** using the [IP2Location.io API](https://www.ip2location.io/). It also provides **domain WHOIS lookup**, **internationalized-domain utilities**, and **hosted-domain lookup**. Its asynchronous methods let .NET applications retrieve IP and domain information without manually constructing REST requests.

**Quick links:** [Get an API key](https://www.ip2location.io/pricing) · [Developer documentation](https://ip2location-io-dotnet.readthedocs.io/en/latest/index.html) · [API reference](https://ip2location-io-dotnet.readthedocs.io/en/latest/code.html) · [NuGet package](https://www.nuget.org/packages/IP2Location.io)

## Features

- **IPv4 and IPv6 geolocation:** Look up country, region, district, city, ZIP/postal code, latitude and longitude.
- **Network and ASN information:** Retrieve available ASN, AS name, ISP, domain, net speed, usage type and related attributes.
- **Time zone and localization data:** Access time zone information, including available DST data; request translated location names on supported plans.
- **Proxy and security signals:** Examine available proxy, VPN, Tor, data center, crawler and fraud-related fields according to your plan.
- **Additional IP intelligence:** Access eligible mobile operator information (MCC/MNC), country metadata and advertising categories.
- **Domain WHOIS lookup:** Retrieve domain registration dates, registrar, nameservers, status and other available registration data.
- **Domain and Punycode utilities:** Convert Unicode domain names to/from Punycode, extract domains from URLs and get domain extensions.
- **Hosted domains:** Retrieve domains hosted on an IPv4 or IPv6 address with optional pagination.
- **Asynchronous .NET lookups:** Use the SDK's task-returning `Lookup()` methods in C# applications.

> **Plan availability:** Available fields vary by API plan and queried IP address. Some WHOIS details may be unavailable or redacted. See the [pricing page](https://www.ip2location.io/pricing) and [API documentation](https://www.ip2location.io/ip2location-documentation).

## SDK classes

The official [.NET SDK reference](https://ip2location-io-dotnet.readthedocs.io/en/latest/index.html) documents the following classes in the `IP2LocationIOComponent` namespace:

| Class | Description |
| --- | --- |
| `Configuration` | Holds the API key through its `ApiKey` property. |
| `IPGeolocation` | Retrieves IP geolocation and available network/security fields using `Lookup(ip, language)`. |
| `DomainWhois` | Performs domain WHOIS lookup and provides `GetPunycode()`, `GetNormalText()`, `GetDomainName()` and `GetDomainExtension()`. |
| `HostedDomain` | Retrieves hosted domains using `Lookup(ip, page)` with optional pagination. |

## API access and query limits

IP2Location.io offers limited keyless geolocation requests through its REST API and a Free plan with an API key:

| API service | Keyless (no API key) | Free plan (with API key) |
| --- | --- | --- |
| IP Geolocation API | **1,000 queries/day** | **50,000 queries/month** |
| Domain WHOIS API | — | **500 queries/month** |
| Hosted Domain API | — | **50 queries/month** |

- **Keyless access:** No registration is needed for the limited [IP Geolocation REST API](https://www.ip2location.io/ip2location-documentation); its allowance resets daily at **00:00 UTC**. The .NET SDK examples below use an API key, as the SDK's documented configuration requires one.
- **Free plan:** Register to obtain an API key and access the published monthly limits.
- **Attribution:** Keyless and Free-plan usage requires attribution; refer to the [pricing page](https://www.ip2location.io/pricing) for current wording and conditions.
- **Paid plans:** Check [pricing](https://www.ip2location.io/pricing) for higher quotas, additional fields and current charges.

## Requirements

- **Microsoft Visual Studio 2022 or later**, as stated in the official repository and quickstart, or an appropriate .NET development environment.
- A compatible .NET target. The [NuGet package](https://www.nuget.org/packages/IP2Location.io) lists **.NET Framework 4.7.2**, **.NET Standard 2.0** and **.NET 5.0** targets; compatibility with other frameworks depends on NuGet's supported framework relationships.
- [NuGet](https://www.nuget.org/) / the .NET SDK to install package dependencies.
- An [IP2Location.io API key](https://www.ip2location.io/pricing) for SDK lookups.
- Internet access to the IP2Location.io API.

The official examples use `Newtonsoft.Json` for optional JSON pretty-printing. The smaller examples below print selected fields directly and do not require an extra pretty-printing statement.

## Installation

Install the official package from [NuGet](https://www.nuget.org/packages/IP2Location.io).

**Option A — .NET CLI:**

```bash
dotnet add package IP2Location.io --version 1.1.2
```

**Option B — Visual Studio Package Manager Console:**

```powershell
Install-Package IP2Location.io -Version 1.1.2
```

**Option C — Add to a `.csproj` file:**

```xml
<PackageReference Include="IP2Location.io" Version="1.1.2" />
```

The version above is the published NuGet version checked when this README was prepared. Consult [NuGet](https://www.nuget.org/packages/IP2Location.io) for newer releases.

### Configure your API key

Store the key in an environment variable instead of committing it to source control.

**Linux / macOS terminal:**

```bash
export IP2LOCATION_API_KEY='YOUR_API_KEY'
```

**Windows Command Prompt:**

```bat
set IP2LOCATION_API_KEY=YOUR_API_KEY
```

**Windows PowerShell:**

```powershell
$env:IP2LOCATION_API_KEY = 'YOUR_API_KEY'
```

The official examples set `Configuration.ApiKey` directly; the quickstart below reads that value from an environment variable.

## Quickstart: IP geolocation lookup

Create a console application if you do not have one:

```bash
dotnet new console -n IP2LocationIoExample
cd IP2LocationIoExample
dotnet add package IP2Location.io --version 1.1.2
```

Replace `Program.cs` with the following C# example. It uses the official `Configuration`, `IPGeolocation` and `Lookup()` API, with an environment variable for the key:

```csharp
using System;
using IP2LocationIOComponent;

var apiKey = Environment.GetEnvironmentVariable("IP2LOCATION_API_KEY");
if (string.IsNullOrWhiteSpace(apiKey))
{
    Console.Error.WriteLine("Set the IP2LOCATION_API_KEY environment variable.");
    return;
}

Configuration config = new() { ApiKey = apiKey };
IPGeolocation geo = new(config);

var result = await geo.Lookup("8.8.8.8", "en");
Console.WriteLine("Country: {0}", result["country_name"]);
Console.WriteLine("City: {0}", result["city_name"]);
Console.WriteLine("ASN: {0}", result["asn"]);
```

Run it from the project folder:

```bash
dotnet run
```

The SDK's `Lookup()` method is asynchronous. The official quickstart demonstrates accessing its task using `.Result`; the example above uses the standard C# `await` syntax instead. Returned fields depend on the queried address and API plan.

## More usage examples

The following snippets assume `using IP2LocationIOComponent;` and a `Configuration config` object have already been defined as in the quickstart. Network lookup snippets use `await` inside an asynchronous method or top-level C# statements.

### Request translated location names

The optional language argument to `IPGeolocation.Lookup(ip, language)` supports translated location fields on **Plus and Security** plans.

```csharp
IPGeolocation geo = new(config);
var result = await geo.Lookup("8.8.8.8", "es");
Console.WriteLine("Country: {0}", result["country_name"]);

if (result["country"] != null)
{
    Console.WriteLine("Country translation: {0}",
        result["country"]?["translation"]?["value"]);
}
```

### Inspect ASN and ISP information

This is an additional use case using the response fields documented in the official geolocation example.

```csharp
IPGeolocation geo = new(config);
var result = await geo.Lookup("8.8.8.8");

Console.WriteLine("ASN: {0}", result["asn"]);
Console.WriteLine("AS: {0}", result["as"]);
Console.WriteLine("ISP: {0}", result["isp"]);
```

More detailed `as_info` attributes, such as `as_name`, `as_number` and `as_cidr`, are available only when included in the response.

### Inspect available proxy indicators

This additional example uses the official `proxy` response object. Security indicators depend on the API plan and may be absent.

```csharp
IPGeolocation geo = new(config);
var result = await geo.Lookup("8.8.8.8");

Console.WriteLine("Is proxy: {0}", result["is_proxy"]);

if (result["proxy"] != null)
{
    Console.WriteLine("VPN: {0}", result["proxy"]?["is_vpn"]);
    Console.WriteLine("Tor: {0}", result["proxy"]?["is_tor"]);
}
```

### Look up domain WHOIS information

The official SDK provides `DomainWhois.Lookup(domain)` for WHOIS lookups. Some fields may be unavailable or redacted.

```csharp
DomainWhois whois = new(config);
var result = await whois.Lookup("example.com");

Console.WriteLine("Domain: {0}", result["domain"]);
Console.WriteLine("Created: {0}", result["create_date"]);
Console.WriteLine("Expires: {0}", result["expire_date"]);
Console.WriteLine("Registrar: {0}", result["registrar"]?["name"]);
```

See the [official WHOIS example](https://ip2location-io-dotnet.readthedocs.io/en/latest/quickstart.html#lookup-domain-information) for additional registration and contact fields.

### Use domain and Punycode utilities

The official `DomainWhois` class documents the following helpers:

```csharp
DomainWhois whois = new(config);

Console.WriteLine(whois.GetPunycode("täst.de"));
Console.WriteLine(whois.GetNormalText("xn--tst-qla.de"));
Console.WriteLine(whois.GetDomainName("https://www.example.com/path"));
Console.WriteLine(whois.GetDomainExtension("example.com"));
```

These utility calls do not require a WHOIS lookup. Their names are specific to the .NET SDK; other language SDKs may use different naming conventions.

### Find domains hosted on an IP address

`HostedDomain.Lookup(ip, page)` supports an optional page number; omitting it returns the first page.

```csharp
HostedDomain hosted = new(config);
var result = await hosted.Lookup("8.8.8.8");

Console.WriteLine("Total domains: {0}", result["total_domains"]);
Console.WriteLine("Current page: {0}", result["page"]);
Console.WriteLine("Domains: {0}", result["domains"]);
```

To request another page, pass the page number as the second argument:

```csharp
var secondPage = await hosted.Lookup("8.8.8.8", 2);
Console.WriteLine("Page: {0}", secondPage["page"]);
```

The response can include `total_domains`, `page`, `per_page`, `total_pages` and `domains`. Check the pagination metadata before requesting additional pages.

## .NET troubleshooting

- **Missing assembly or namespace:** Confirm that `IP2Location.io` is installed in the active project and that the C# file includes `using IP2LocationIOComponent;`.
- **API authentication errors:** Confirm that `IP2LOCATION_API_KEY` is set in the terminal or application environment where the program is running.
- **Unavailable data fields:** Check the plan's field entitlements and use null-aware access for optional nested objects.
- **Asynchronous lookups:** Use `await` in an asynchronous context. The official samples also demonstrate task `.Result` access.
- **Framework compatibility:** Verify your project's target framework against the compatibility information on the [NuGet package page](https://www.nuget.org/packages/IP2Location.io).

## Common use cases

- **Website and application localization:** Suggest region-appropriate content or language based on approximate IP location.
- **Traffic analytics:** Enrich application requests and logs with country, city, ISP or ASN information.
- **Security review:** Combine available proxy, VPN, Tor and fraud-related indicators with other security checks rather than relying on IP intelligence alone.
- **Domain research:** Investigate available registration dates, registrars and nameservers using domain WHOIS.
- **Hosting and network research:** Examine AS information and domains hosted on an IP address.

## Documentation and support

- [.NET SDK documentation](https://ip2location-io-dotnet.readthedocs.io/en/latest/index.html)
- [Official .NET quickstart and sample codes](https://ip2location-io-dotnet.readthedocs.io/en/latest/quickstart.html)
- [.NET SDK API reference](https://ip2location-io-dotnet.readthedocs.io/en/latest/code.html)
- [Official GitHub repository](https://github.com/ip2location/ip2location-io-dotnet)
- [IP2Location.io on NuGet](https://www.nuget.org/packages/IP2Location.io)
- [API plans and query limits](https://www.ip2location.io/pricing)
- [IP Geolocation API documentation](https://www.ip2location.io/ip2location-documentation)
- [Report a .NET SDK bug or request a feature](https://github.com/ip2location/ip2location-io-dotnet/issues)
- [API and account support](https://www.ip2location.io/contact-us)

## License

Licensed under the **MIT License**. See [LICENSE](./LICENSE).
