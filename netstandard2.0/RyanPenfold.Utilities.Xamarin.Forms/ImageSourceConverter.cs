using Xamarin.Forms;

namespace RyanPenfold.Utilities.Xamarin.Forms
{
    public class ImageSourceConverter : IValueConverter
    {
        private static readonly System.Net.WebClient Client;

        static ImageSourceConverter()
        {
            Client = new System.Net.WebClient();
        }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var url = Uri.SanitiseUrl(value.ToString());
            var byteArray = Client.DownloadData(url);
            return ImageSource.FromStream(() => new System.IO.MemoryStream(byteArray));
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
