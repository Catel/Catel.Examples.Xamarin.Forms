using Catel.Data;
using Newtonsoft.Json;

namespace GitMeet.Models
{
    public class UserInfo : ModelBase
    {
        /// <summary>Register the Id property so it is known in the class.</summary>
        public static readonly PropertyData IdProperty = RegisterProperty<UserInfo, string>(model => model.Id);

        /// <summary>Register the UserName property so it is known in the class.</summary>
        public static readonly PropertyData UserNameProperty = RegisterProperty<UserInfo, string>(model => model.UserName);

        /// <summary>Register the DisplayName property so it is known in the class.</summary>
        public static readonly PropertyData DisplayNameProperty = RegisterProperty<UserInfo, string>(model => model.DisplayName);

        /// <summary>Register the Url property so it is known in the class.</summary>
        public static readonly PropertyData UrlProperty = RegisterProperty<UserInfo, string>(model => model.Url);

        /// <summary>Register the AvatarUrlSmall property so it is known in the class.</summary>
        public static readonly PropertyData AvatarUrlSmallProperty = RegisterProperty<UserInfo, string>(model => model.AvatarUrlSmall);

        /// <summary>Register the AvatarUrlMedium property so it is known in the class.</summary>
        public static readonly PropertyData AvatarUrlMediumProperty = RegisterProperty<UserInfo, string>(model => model.AvatarUrlMedium);

        [JsonProperty("id")]
        public string Id
        {
            get { return GetValue<string>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        [JsonProperty("userName")]
        public string UserName
        {
            get { return GetValue<string>(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        [JsonProperty("displayName")]
        public string DisplayName
        {
            get { return GetValue<string>(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        [JsonProperty("url")]
        public string Url
        {
            get { return GetValue<string>(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        [JsonProperty("avatarUrlSmall")]
        public string AvatarUrlSmall
        {
            get { return GetValue<string>(AvatarUrlSmallProperty); }
            set { SetValue(AvatarUrlSmallProperty, value); }
        }

        [JsonProperty("avatarUrlMedium")]
        public string AvatarUrlMedium
        {
            get { return GetValue<string>(AvatarUrlMediumProperty); }
            set { SetValue(AvatarUrlMediumProperty, value); }
        }
    }
}