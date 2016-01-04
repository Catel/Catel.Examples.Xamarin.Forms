namespace GitMeet.Models
{
    using Catel.Data;
    using Newtonsoft.Json;

    /// <summary>
    ///     The room info/
    /// </summary>
    public sealed class RoomInfo : ModelBase
    {
        /// <summary>Register the UnreadItems property so it is known in the class.</summary>
        public static readonly PropertyData UnreadItemsProperty = RegisterProperty<RoomInfo, int>(model => model.UnreadItems);

        /// <summary>Register the Id property so it is known in the class.</summary>
        public static readonly PropertyData IdProperty = RegisterProperty<RoomInfo, string>(model => model.Id);

        /// <summary>Register the Name property so it is known in the class.</summary>
        public static readonly PropertyData NameProperty = RegisterProperty<RoomInfo, string>(model => model.Name, default(string), (s, e) => s.OnNameChanged(e));

        [JsonProperty("id")]
        public string Id
        {
            get { return GetValue<string>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        [JsonProperty("name")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        [JsonProperty("unreadItems")]
        public int UnreadItems
        {
            get { return GetValue<int>(UnreadItemsProperty); }
            set { SetValue(UnreadItemsProperty, value); }
        }

        /// <summary>
        /// Gets the avatar url.
        /// </summary>
        public string AvatarUrl => "https://avatars2.githubusercontent.com/" + Name.Split('/')[0];

        /// <summary>Occurs when the value of the Name property is changed.</summary>
        /// <param name="e">The event argument</param>
        private void OnNameChanged(AdvancedPropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(AvatarUrl));
        }
    }
}