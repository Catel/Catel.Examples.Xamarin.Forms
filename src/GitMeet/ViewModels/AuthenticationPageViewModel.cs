using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Catel;
using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using GitMeet.Services.Interfaces;
using Newtonsoft.Json;

namespace GitMeet.ViewModels
{
    /// <summary>
    /// </summary>
    public sealed class AuthenticationPageViewModel : ViewModelBase
    {
        /// <summary>Register the Url property so it is known in the class.</summary>
        public static readonly PropertyData UrlProperty =
            RegisterProperty<AuthenticationPageViewModel, string>(model => model.Url,
                AuthorizationFlowWellKnownUrls.GitHubLoginRequestPageUrl, (s, e) => s.OnNavigateUrlChanged(e));

        /// <summary>Register the IsWebViewVisible property so it is known in the class.</summary>
        public static readonly PropertyData IsWebViewVisibleProperty = RegisterProperty<AuthenticationPageViewModel, bool>(model => model.IsWebViewVisible, true);

        /// <summary>
        ///     The credential store.
        /// </summary>
        private readonly ICredentialStore _credentialStore;

        /// <summary>
        ///     The navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <exception cref="System.ArgumentNullException">The <paramref name="credentialStore" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="navigationService" /> is <c>null</c>.</exception>
        public AuthenticationPageViewModel(ICredentialStore credentialStore, INavigationService navigationService)
        {
            Argument.IsNotNull(() => credentialStore);
            Argument.IsNotNull(() => navigationService);

            _credentialStore = credentialStore;
            _navigationService = navigationService;
        }

        public bool IsWebViewVisible
        {
            get { return GetValue<bool>(IsWebViewVisibleProperty); }
            set { SetValue(IsWebViewVisibleProperty, value); }
        }

        /// <summary>
        ///     The Url.
        /// </summary>
        public string Url
        {
            get { return GetValue<string>(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        protected override Task InitializeAsync()
        {
            _navigationService.RemoveBackEntry();
            return base.InitializeAsync();
        }

        /// <summary>Occurs when the value of the Url property is changed.</summary>
        /// <param name="e">The event argument</param>
        private async void OnNavigateUrlChanged(AdvancedPropertyChangedEventArgs e)
        {
            if (AuthorizationFlowWellKnownUrls.GitHubHomePageUrl.Equals(Url))
            {
                Url = AuthorizationFlowWellKnownUrls.AuthorizationRequestPageUrl;
            }
            else if (Url != null && Url.StartsWith(AuthorizationFlowWellKnownUrls.CallBackUrl))
            {
                // TODO: Create a static page as resource an show it in the WebView?
                IsWebViewVisible = false;

                var queryStringMap = new Dictionary<string, string>();
                var urlSplitted = Url.Split('?');
                if (urlSplitted.Length == 2)
                {
                    var parameters = urlSplitted[1].Split('&');
                    foreach (var parameter in parameters)
                    {
                        var splittedParameter = parameter.Split('=');
                        if (splittedParameter.Length == 2)
                        {
                            queryStringMap.Add(splittedParameter[0], splittedParameter[1]);
                        }
                    }
                }

                if (queryStringMap.ContainsKey(Messages.TokenExchangeRequest.Code))
                {
                    var code = queryStringMap[Messages.TokenExchangeRequest.Code];

                    //// TODO: Extract this as a service method.
                    var client = new HttpClient();
                    var data = new Dictionary<string, string>
                    {
                        {Messages.TokenExchangeRequest.ClientId, AppInfo.ClientId},
                        {Messages.TokenExchangeRequest.ClientSecret, AppInfo.ClientSecret},
                        {Messages.TokenExchangeRequest.Code, code},
                        {Messages.TokenExchangeRequest.RedirectUri, AppInfo.CallBackUrl},
                        {Messages.TokenExchangeRequest.GrantType, Messages.GrantType.AuthorizationCode }
                    };

                    var httpResponseMessage = await client.PostAsync(new Uri("https://gitter.im/login/oauth/token"), new FormUrlEncodedContent(data));
                    var httpContent = httpResponseMessage.Content;
                    var result = await httpContent.ReadAsStringAsync();
                    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                    if (dictionary.ContainsKey(Messages.TokenExchangeResponse.AccessToken))
                    {
                        var accessToken = dictionary[Messages.TokenExchangeResponse.AccessToken];
                        _credentialStore.SaveToken(accessToken);
                    }

                    _navigationService.Navigate<MainPageViewModel>();
                }
            }
        }
    }
}