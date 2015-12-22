using Catel;
using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using GitMeet.Services.Interfaces;
using Xamarin.Forms;

namespace GitMeet.ViewModels
{
    /// <summary>
    /// </summary>
    public sealed class AuthenticationPageViewModel : ViewModelBase
    {

        /// <summary>Register the Url property so it is known in the class.</summary>
        public static readonly PropertyData UrlProperty = RegisterProperty<AuthenticationPageViewModel, string>(model => model.Url, "http://192.168.42.56:8080/authorize.html", (s, e) => s.OnNavigateUrlChanged(e));

        /// <summary>
        /// The credential store.
        /// </summary>
        private readonly ICredentialStore _credentialStore;

        /// <summary>
        /// The navigation service.
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

        /// <summary>
        /// The Url.
        /// </summary>
        public string Url
        {
            get { return GetValue<string>(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        /// <summary>Occurs when the value of the Url property is changed.</summary>
        /// <param name="e">The event argument</param>
        private void OnNavigateUrlChanged(AdvancedPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue;
        }
    }
}