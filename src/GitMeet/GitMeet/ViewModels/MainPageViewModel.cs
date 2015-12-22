using System.Threading.Tasks;
using Catel;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using GitMeet.Services.Interfaces;

namespace GitMeet.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICredentialStore _credentialStore;

        /// <summary>
        /// 
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// 
        /// </summary>
        private readonly IGitterService _gitterService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentialStore"></param>
        /// <param name="visualizerService"></param>
        /// <param name="gitterService"></param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="credentialStore"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="navigationService"/> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="gitterService"/> is <c>null</c>.</exception>
        public MainPageViewModel(ICredentialStore credentialStore, INavigationService navigationService, IGitterService gitterService)
        {
            Argument.IsNotNull(() => credentialStore);
            Argument.IsNotNull(() => navigationService);
            Argument.IsNotNull(() => gitterService);

            _credentialStore = credentialStore;
            _navigationService = navigationService;
            _gitterService = gitterService;
        }

        protected override Task Initialize()
        {
            Execute();
            return new Task(()=> { });
        }

        private void Execute()
        {
            var token = _credentialStore.ReadToken();
            if (token == null)
            {
                _navigationService.Navigate<AuthenticationPageViewModel>();
            }

            token = _credentialStore.ReadToken();
            if (token != null)
            {
            }
        }
    }
}