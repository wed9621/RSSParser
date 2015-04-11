using RSSParcer2._0.Resources;

namespace RSSParcer2._0
{
    /// <summary>
    /// Предоставляет доступ к строковым ресурсам.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}