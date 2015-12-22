namespace GitMeet.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICredentialStore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ReadToken();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        void SaveToken(string token);
    }
}