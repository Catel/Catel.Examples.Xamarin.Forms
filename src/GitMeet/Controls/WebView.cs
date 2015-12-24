// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebView.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace GitMeet.Controls
{
    using Xamarin.Forms;

    public class WebView : Xamarin.Forms.WebView
    {
        public static readonly BindableProperty UrlProperty = BindableProperty.Create<WebView, string>(view => view.Url, default(string), propertyChanged: (bindable, value, newValue) => { ((WebView) bindable).OnNavigateUrlChanged(value, newValue); });

        public WebView()
        {
            this.Navigating += OnNavigating;
        }

        public string Url
        {
            get { return (string) GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs webNavigatingEventArgs)
        {
            if (Url != webNavigatingEventArgs.Url)
            {
                webNavigatingEventArgs.Cancel = false;
                Url = webNavigatingEventArgs.Url;
            }
        }

        private void OnNavigateUrlChanged(string oldValue, string newValue)
        {
            Source = new UrlWebViewSource
            {
                Url = newValue
            };
        }
    }
}