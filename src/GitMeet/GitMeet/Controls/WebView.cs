using System;
using Xamarin.Forms;

namespace GitMeet.Controls
{
    public class WebView : Xamarin.Forms.WebView
    {
        public static readonly BindableProperty UrlProperty = BindableProperty.Create<WebView, string>(view => view.Url, default(string), propertyChanged: (bindable, value, newValue) => { ((WebView) bindable).OnNavigateUrlChanged(value, newValue); });

        public WebView()
        {
            this.Navigating += OnNavigating;
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs webNavigatingEventArgs)
        {
            if (this.Url != webNavigatingEventArgs.Url)
            {
                webNavigatingEventArgs.Cancel = false;
                this.Url = webNavigatingEventArgs.Url;
            }
        }

        public string Url
        {
            get { return (string) GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        private void OnNavigateUrlChanged(string oldValue, string newValue)
        {
            this.Source = new UrlWebViewSource { Url = newValue };
        }
    }
}