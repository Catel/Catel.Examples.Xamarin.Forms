using Catel.Data;
using Newtonsoft.Json;

namespace GitMeet.Models
{
    /// <summary>
    ///     The room info/
    /// </summary>
    public sealed class RoomInfo : ModelBase
    {
        /// <summary>Register the Name property so it is known in the class.</summary>
        public static readonly PropertyData NameProperty = RegisterProperty<RoomInfo, string>(model => model.Name);

        /// <summary>Register the UnreadItems property so it is known in the class.</summary>
        public static readonly PropertyData UnreadItemsProperty = RegisterProperty<RoomInfo, int>(model => model.UnreadItems);

        /// <summary>Register the Id property so it is known in the class.</summary>
        public static readonly PropertyData IdProperty = RegisterProperty<RoomInfo, string>(model => model.Id);

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
    }
}