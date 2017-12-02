namespace RyanPenfold.Utilities.Localization
{
    public class StringLocalizer<TResourceSource> : Microsoft.Extensions.Localization.StringLocalizer<TResourceSource>, Microsoft.Extensions.Localization.IStringLocalizer<TResourceSource>
    {
        static StringLocalizer()
        {
            // TODO: Load resources from database
        }

        public StringLocalizer(Microsoft.Extensions.Localization.IStringLocalizerFactory factory) : base(factory)
        {
        }

        private System.Collections.Generic.IDictionary<string, string> values = new System.Collections.Generic.Dictionary<string, string>();

        public new string this[string index] => this.values[index];
    }
}
