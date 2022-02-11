# An ASP.NET Core IdentityServer4 Identity Template with Bootstrap 4 and Localization

[![.NET](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/actions/workflows/dotnet.yml/badge.svg)](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/actions/workflows/dotnet.yml) [![NuGet Status](http://img.shields.io/nuget/v/IdentityServer4AspNetCoreIdentityTemplate.svg?style=flat-square)](https://www.nuget.org/packages/IdentityServer4AspNetCoreIdentityTemplate/) [Change log](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/blob/master/Changelog.md)

## Features

- ASP.NET Core 6
- Latest ASP.NET Core Identity
- Bootstrap 4 UI
- Localization en-US, de-DE, it-IT, fr-FR, zh-Hans, es-MX, de-CH, ga-IE, gsw-CH
- 2FA
- TOTP
- FIDO2 MFA
- Personal data, download, delete (part of Identity)
- Azure AD, Cert, key vault deployments API
- SendGrid Email API
- npm with bundleconfig used for frontend packages
- EF Core
- Support for ui_locales using OIDC logins

some print screens:

it-IT

![it-IT](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/blob/main/images/it-IT_template.png)

de-DE

![de-DE](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/blob/main/images/de-DE_template.png)

en-US

![en-US](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/blob/main/images/en-US_template.png)

fr-FR

![fr-FR](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/blob/main/images/fr-FR_template.png)

zh-Hans

![zh-Hans](https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate/blob/main/images/zh-Hans_template.png)

## Using the template

### install

From NuGet:

```
dotnet new -i IdentityServer4AspNetCoreIdentityTemplate
```

Locally built nupkg:

```
dotnet new -i IdentityServer4AspNetCoreIdentityTemplate.6.0.1.nupkg
```

Local folder:

```
dotnet new -i <PATH>
```

Where `<PATH>` is the path to the folder containing .template.config.

### run

```
dotnet new sts -n YourCompany.Sts
```

Use the `-n` or `--name` parameter to change the name of the output created. This string is also used to substitute the namespace name in the .cs file for the project.

### Setup, Using the application for your System

- Change the EF Core code from SQLite to your required database
- Change the ApplicationUser class as required, remove/add the properties
- Add the migrations and create the database
- Define the deployment URLs, create the certs, and use these in your application (Startup, config files)
- Add the external providers for login as required, or remove
- Remove the UI views which are not required
- Add remove the resource file localizations and also in the Startup.
- Add the client configuration to the Config.cs class (dev, test, staging, prod, or whatever)
- Update the claims in the IdentityWithAdditionalClaimsProfileService
- Add the security headers as required, CSP, IFrame, XSS, HSTS, ...
- If you deploy in a multi instance environment, add the session data to a database using the IdentityServer4.EntityFramework NuGet package
- Add "AZURE_TENANT_ID": "your-tenandId" to the launch settings to test in VS with Azure Key Vault certificates

### uninstall

```
dotnet new -u IdentityServer4AspNetCoreIdentityTemplate
```

## Development

### build

https://docs.microsoft.com/en-us/dotnet/core/tutorials/create-custom-template

```
nuget pack content/IdentityServer4AspNetCoreIdentityTemplate.nuspec
```

### dotnet Migrations

#### open the cmd in project folder:

```
dotnet restore

dotnet ef migrations add sts_init --context ApplicationDbContext --verbose

dotnet ef database update  --verbose
```

## Using Powershell to create the self signed certs:

```
New-SelfSignedCertificate -DnsName "sts.dev.cert.com", "sts.dev.cert.com" -CertStoreLocation "cert:\LocalMachine\My"

$mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText

Get-ChildItem -Path cert:\localMachine\my\"The thumbprint..." | Export-PfxCertificate -FilePath C:\git\sts_dev_cert.pfx -Password $mypwd
```

## Credits, Used NuGet packages + ASP.NET Core 3.1 standard packages

- IdentityServer4
- IdentityServer4.AspNetIdentity
- Azure.Security.KeyVault.Secrets
- Microsoft.IdentityModel.Clients.ActiveDirectory
- Sendgrid
- NetEscapades.AspNetCore.SecurityHeaders
- Serilog

## Links

http://docs.identityserver.io/en/release/

https://github.com/IdentityServer/IdentityServer4

https://getbootstrap.com/

https://nodejs.org/en/

https://www.npmjs.com/
