using GitMeet.Services.Interfaces;

namespace GitMeet.Services
{
    /// <summary>
    /// The credential store service.
    /// </summary>
    public sealed class CredentialStore : ICredentialStore
    {
        //TODO: Store this on the device.
        private static string _token = null;

        /// <summary>
        /// Reads the token
        /// </summary>
        /// <returns></returns>
        public string ReadToken()
        {
            return _token;
        }

        /// <summary>
        /// Save the token.
        /// </summary>
        /// <param name="token"></param>
        public void SaveToken(string token)
        {
            _token = token;
        }
    }
}