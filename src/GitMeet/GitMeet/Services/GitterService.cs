using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using GitMeet.Models;
using GitMeet.Services.Interfaces;
using Newtonsoft.Json;

namespace GitMeet.Services
{
    public sealed class GitterService : IGitterService
    {
        private const string ApiUrl = "https://api.gitter.im";

        public async Task<UserInfo> GetUserInfo(string accessToken)
        {
            var client2 = new HttpClient();
            var userData = await client2.GetStringAsync(string.Format(CultureInfo.InvariantCulture, "{0}/v1/user?access_token={1}", ApiUrl, accessToken));
            return JsonConvert.DeserializeObject<UserInfo[]>(userData)[0];
        }
    }
}