using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Localization;
using StsServerIdentity.Resources;

namespace StsServerIdentity
{
    public static class StartupLocalizationConfiguations
    {
        public static void AddLocalizationConfigurations(this IServiceCollection services)
        {
            services.AddSingleton<LocService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                        {
                            new CultureInfo("en-US"),
                            new CultureInfo("de-DE"),
                            new CultureInfo("de-CH"),
                            new CultureInfo("it-IT"),
                            new CultureInfo("gsw-CH"),
                            new CultureInfo("fr-FR"),
                            new CultureInfo("zh-Hans")
                        };

                    options.DefaultRequestCulture = new RequestCulture(culture: "de-DE", uiCulture: "de-DE");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;

                    var providerQuery = new LocalizationQueryProvider
                    {
                        QureyParamterName = "ui_locales"
                    };

                    options.RequestCultureProviders.Insert(0, providerQuery);
                });
        }
    }
}
