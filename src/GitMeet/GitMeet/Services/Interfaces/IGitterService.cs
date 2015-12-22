using System.Threading.Tasks;
using GitMeet.Models;

namespace GitMeet.Services.Interfaces
{
    public interface IGitterService
    {
        Task<UserInfo> GetUserInfo(string token);
        Task<RoomInfo[]> GetRooms(string accessToken);
    }
}
