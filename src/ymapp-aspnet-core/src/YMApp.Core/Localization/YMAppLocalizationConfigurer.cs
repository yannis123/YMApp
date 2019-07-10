using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace YMApp.Localization
{
    public static class YMAppLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("zh", "¼òÌåÖÐÎÄ", "famfamfam-flags cn", true));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(YMAppConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(YMAppLocalizationConfigurer).GetAssembly(),
                        "YMApp.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
