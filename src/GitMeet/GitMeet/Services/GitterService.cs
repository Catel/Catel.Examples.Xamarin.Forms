using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using GitMeet.Models;
using GitMeet.Services.Interfaces;
using Newtonsoft.Json;

namespace GitMeet.Services
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GitterService : IGitterService
    {
        /// <summary>
        /// 
        /// </summary>
        private const string ApiUrl = "https://api.gitter.im";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfo(string accessToken)
        {
            var httpClient = new HttpClient();
            var userData = await httpClient.GetStringAsync(string.Format(CultureInfo.InvariantCulture, "{0}/v1/user?access_token={1}", ApiUrl, accessToken));
            return JsonConvert.DeserializeObject<UserInfo[]>(userData)[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<RoomInfo[]> GetRooms(string accessToken)
        {
            var httpClient = new HttpClient();
            var roomData = await httpClient.GetStringAsync(string.Format(CultureInfo.InvariantCulture, "{0}/v1/rooms?access_token={1}", ApiUrl, accessToken));
            return JsonConvert.DeserializeObject<RoomInfo[]>(roomData);
        }
    }
}