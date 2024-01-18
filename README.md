# Deepstack .NET SDK

[![NuGet](https://img.shields.io/nuget/v/globallypaid.net.svg)](https://www.nuget.org/packages/GloballyPaid.net/)
![CI](https://github.com/globallypaid/globallypaid-sdk-dotnet/workflows/CI/badge.svg)

The official Deepstack .NET library

Supporting [.NET Standard 2.0][netstandard]

// Update installing after fixing deployment for deepstack...

## Installation

## Installation Notice

Until further notice, the current installation methods will not work since the deployments are not synced. This will be changed soon, but for now, all SDK installations should be done through the Deepstack Github.


Using the [.NET Core CLI tools][dotnet-core-cli-tools]:

```sh
dotnet add package DeepStack.net
```

Using the [NuGet CLI][nuget-cli]:

```sh
nuget install DeepStack.net
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package DeepStack.net
```

From within Visual Studio:

1. Open Solution Explorer
2. Right-click on a project within your solution
3. Click on *Manage NuGet Packages*
4. Click on the *Browse* tab and search for **GloballyPaid.net**
5. Click on the **DeepStack.net** package, select version in the
   right-tab 
6. Click *Install*

## Documentation

For the Deepstack API documentation, please visit [Deepstack API documentation][gp-api-docs] 

## Samples

For a comprehensive list of examples, please visit [Globally Paid .NET SDK samples][gp-dotnet-samples].

## Usage

### Configuration

There are three ways to configure the Globally Paid SDK:

##### 1. Startup Extension

All SDK calls can be configured within `ConfigureServices` method in `Startup` class using the `AddGloballyPaid` extension.
Additionally, this extension call will register all Deepstack services:

```c#
services.AddGloballyPaid("Your Publishable API Key", "Your Shared Secret", "Your APP ID", useSandbox: false, requestTimeoutSeconds: 90);
```

To register the Deepstack services only, `AddDeepStackServices` extension can be used:

```c#
services.AddDeepStackServices();
```

##### 2. DeepStackConfiguration object

All SDK calls can be configured using the static `DeepStackConfiguration` object:

```c#
DeepStackConfiguration.PublishableApiKey = "Your Publishable API Key";
DeepStackConfiguration.SharedSecret = "Your Shared Secret";
DeepStackConfiguration.AppId = "Your APP ID";
DeepStackConfiguration.UseSandbox = false; //true if you need to test through Globally Paid sandbox
DeepStackConfiguration.RequestTimeoutSeconds = 90;
```
Or using the `DeepStackConfiguration` *Setup* method:

```c#
DeepStackConfiguration.Setup("Your Publishable API Key", "Your Shared Secret", "Your APP ID", useSandbox: false, requestTimeoutSeconds: 90);
```

##### 3. The `<appSettings>` section

All SDK calls can be configured using the `<appSettings>` section in configuration files (App.config or web.config):

```xml
<appSettings>
    <add key="DeepStackPublishableApiKey" value="Your Publishable API Key"></add>
    <add key="DeepStackSharedSecret" value="Your Shared Secret"></add>
    <add key="DeepStackAppId" value="Your APP ID"></add>
    <add key="DeepStackUseSandbox" value="false"></add> <!--true if you need to test through Globally Paid sandbox-->
    <add key="DeepStackRequestTimeoutSeconds" value="90"></add>
</appSettings>
```

#### Per-request configuration

All SDK service methods accept an optional `RequestOptions` object, additionally allowing per-request configuration:

```c#
var requestOptions = new RequestOptions("Your Publishable API Key", "Your Shared Secret", "Your APP ID", useSandbox: false, requestTimeoutSeconds: 90);
```
---

### Sample Charge Sale Transaction
```c#
var request = new ChargeRequest
            {
                Source = "source", //this can be the token or payment instrument identifier
                Amount = 1299,
                Capture = true, //sale charge
                ClientCustomerId = "12345", //set your customer id
                ClientInvoiceId = "IX213", //set your invoice id
                ClientTransactionDescription = "Tuition for CS" //set your transaction description
            };

//if Deepstack services are registered, you can inject this as IChargeService in the constructor
var chargeService = new ChargeService(); 
var charge = chargeService.Charge(request);
```

---
For any feedback or bug/enhancement report, please [open an issue][issues] or [submit a
pull request][pulls].

[gp]: https://www.deepstack.io/
[gp-api-docs]: https://qa-v2.docs.globallypaid.com/
[gp-dotnet-samples]: https://github.com/globallypaid/globallypaid-sdk-dotnet-samples
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions.md
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[dotnet-format]: https://github.com/dotnet/format
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[issues]: https://github.com/globallypaid/globallypaid-sdk-dotnet/issues/new
[pulls]: https://github.com/globallypaid/globallypaid-sdk-dotnet/pulls
