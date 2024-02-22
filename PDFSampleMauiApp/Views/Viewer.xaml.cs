using Android.Hardware;
using Android.Nfc;
using Android.Util;
using Java.Util.Logging;
using System.Net;

namespace PDFSampleMauiApp.Views;

/// <summary>
/// View class to display the WebView
/// </summary>
public partial class Viewer : ContentPage
{
    public Viewer()
    {
        String tag = "Viewer";
        try
        {
            Log.Info(tag, "In Viewer class");
            InitializeComponent();

            //For opening PDF from mail -now checking only with local PDF file
            //custwebview.Uri = filePath;

            custwebview.HeightRequest = 800;
            custwebview.WidthRequest = 400;
            // custwebview.Source = $"file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/{WebUtility.UrlEncode("mypdf.pdf")}";
           // custwebview.Uri = "mypdf.pdf";
        }
        catch (Exception ex)
        {
            Log.Error(tag, "Exception :" + ex.Message);
        }
    }
}