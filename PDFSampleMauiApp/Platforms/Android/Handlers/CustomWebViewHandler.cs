using Android.Hardware;
using Java.Util.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using PDFSampleMauiApp.Views.Controls;
using static Android.Views.ViewGroup;
using System.Net;
using AndroidWebview = Android.Webkit.WebView;
using Android.Util;

namespace PDFSampleMauiApp.Droid
{
    /// <summary>
    /// Custom web view handler class for Viewer functionality in MAUI
    /// </summary>
    public partial class CustomWebViewHandler : ViewHandler<CustomWebView, Android.Webkit.WebView> //WebViewHandler 
    {
        String tag = "CustomWebViewHandler";
        public CustomWebViewHandler() : base(PropertyMapper)
        {
            Log.Info(tag, "Info : In CustomWebViewHandler class");

        }
        //public CustomWebViewHandler(IPropertyMapper mapper, CommandMapper commandMapper = null) : base(mapper, commandMapper)
        //{
        //}

        public static PropertyMapper<CustomWebView, CustomWebViewHandler> PropertyMapper = new PropertyMapper<CustomWebView, CustomWebViewHandler>(WebViewHandler.ViewMapper)
        {

        };


        protected override AndroidWebview CreatePlatformView()
        {
            var webView = new AndroidWebview(Context);

            try
            {
                Log.Info(tag, "In CreatePlatformView method:");

                if (webView != null)
                {
                    //Getting filename from Uri property of Control class
                    var virview = VirtualView as CustomWebView;
                    string fileName = virview.Uri;

                    webView.Settings.AllowFileAccess = true;
                    webView.Settings.AllowFileAccessFromFileURLs = true;
                    webView.Settings.AllowUniversalAccessFromFileURLs = true;

                    //Newly added
                    webView.Settings.JavaScriptEnabled = true;
                    webView.Settings.DomStorageEnabled = true;
                    webView.Settings.LoadWithOverviewMode = true;
                    webView.Settings.UseWideViewPort = true;
                    webView.Settings.BuiltInZoomControls = true;
                    webView.Settings.DisplayZoomControls = false;
                    webView.Settings.SetSupportZoom(true);
                    webView.Settings.AllowContentAccess = true;
                   // webView.Settings.SetAppCacheEnabled(true);
                    webView.Settings.DefaultTextEncodingName = "UTF-8";
                    webView.SetWebViewClient(new Android.Webkit.WebViewClient());

                    // For opening pdf file from mail
                    //if (File.Exists(virview.Uri))                                    
                    // string url = string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", "file://" + fileName); 

                    // For local pdf file
                    //  string url = string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", "file:///android_asset/Content/sample.pdf");

                    string url = $"file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/{WebUtility.UrlEncode("mypdf.pdf")}";
                    Log.Debug(tag, "URL::::: " + url);

                    webView.LoadUrl(url);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(tag, "Exception :" + ex.Message);
            }
            return webView;
        }
        protected override void ConnectHandler(AndroidWebview platformview)
        {
            base.ConnectHandler(platformview);
        }
    }
}
