using Android.Util;
using Java.Util.Logging;

namespace PDFSampleMauiApp.Views.Controls
{
    /// <summary>
    /// Custom web view class- control class for Custom handlers in MAUI
    /// </summary>
    public class CustomWebView : WebView
    {
        String tag = "CustomWebView";
        //Parameter to get the filename of PDF
        public static readonly BindableProperty UriProperty = BindableProperty.Create(nameof(Uri), typeof(string), typeof(CustomWebView), default(string));
        public CustomWebView()
        {
            Log.Info(tag, "Info : In CustomWebView class");
        }
        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }
}
