using GitMeet.Services.Interfaces;

namespace GitMeet.Services
{
    public sealed class CredentialStore : ICredentialStore
    {
        public string ReadToken()
        {
            return null;
        }

        public void SaveToken(string token)
        {
        }
    }
}