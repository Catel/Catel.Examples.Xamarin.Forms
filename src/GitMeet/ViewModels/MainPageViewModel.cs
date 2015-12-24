using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Catel;
using Catel.Collections;
using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using GitMeet.Models;
using GitMeet.Services.Interfaces;

namespace GitMeet.ViewModels
{
    /// <summary>
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>Register the AvatarUrlMedium property so it is known in the class.</summary>
        public static readonly PropertyData AvatarUrlMediumProperty =
            RegisterProperty<MainPageViewModel, string>(model => model.AvatarUrlMedium);

        /// <summary>Register the UserInfo property so it is known in the class.</summary>
        public static readonly PropertyData UserInfoProperty =
            RegisterProperty<MainPageViewModel, UserInfo>(model => model.UserInfo, default(UserInfo),
                (s, e) => s.OnUserInfoChanged(e));

        /// <summary>Register the DisplayName property so it is known in the class.</summary>
        public static readonly PropertyData DisplayNameProperty =
            RegisterProperty<MainPageViewModel, string>(model => model.DisplayName);

        /// <summary>Register the Rooms property so it is known in the class.</summary>
        public static readonly PropertyData RoomsProperty = RegisterProperty<MainPageViewModel, ObservableCollection<RoomInfo>>(model => model.Rooms, () => new ObservableCollection<RoomInfo>());

        /// <summary>
        /// </summary>
        private readonly ICredentialStore _credentialStore;

        /// <summary>
        /// </summary>
        private readonly IGitterService _gitterService;

        /// <summary>
        /// </summary>
        private readonly INavigationService _navigationService;

        private string _accessToken;


        /// <summary>
        /// </summary>
        /// <param name="credentialStore"></param>
        /// <param name="visualizerService"></param>
        /// <param name="gitterService"></param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="credentialStore" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="navigationService" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="gitterService" /> is <c>null</c>.</exception>
        public MainPageViewModel(ICredentialStore credentialStore, INavigationService navigationService,
            IGitterService gitterService)
        {
            Argument.IsNotNull(() => credentialStore);
            Argument.IsNotNull(() => navigationService);
            Argument.IsNotNull(() => gitterService);

            _credentialStore = credentialStore;
            _navigationService = navigationService;
            _gitterService = gitterService;
        }

        [Model]
        public UserInfo UserInfo
        {
            get { return GetValue<UserInfo>(UserInfoProperty); }
            set { SetValue(UserInfoProperty, value); }
        }

        [ViewModelToModel("UserInfo")]
        public string DisplayName
        {
            get { return GetValue<string>(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        public ObservableCollection<RoomInfo> Rooms
        {
            get { return GetValue<ObservableCollection<RoomInfo>>(RoomsProperty); }
            set { SetValue(RoomsProperty, value); }
        }

        [ViewModelToModel("UserInfo")]
        public string AvatarUrlMedium
        {
            get { return GetValue<string>(AvatarUrlMediumProperty); }
            set { SetValue(AvatarUrlMediumProperty, value); }
        }

        /// <summary>Occurs when the value of the UserInfo property is changed.</summary>
        /// <param name="e">The event argument</param>
        private async void OnUserInfoChanged(AdvancedPropertyChangedEventArgs e)
        {
            this.Rooms.Clear();
            this.Rooms.AddRange(await _gitterService.GetRooms(_accessToken));
        }


        protected override Task Initialize()
        {
            Execute();
            return new Task(() => { });
        }

        private async void Execute()
        {
            _accessToken = _credentialStore.ReadToken();
            if (_accessToken == null)
            {
                _navigationService.Navigate<AuthenticationPageViewModel>();
            }
            else
            {
                UserInfo = await _gitterService.GetUserInfo(_accessToken);
            }
        }
    }
}