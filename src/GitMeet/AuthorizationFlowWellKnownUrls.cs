// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationFlowWellKnownUrls.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace GitMeet
{
    /// <summary>
    /// The authorization flow well known urls.
    /// </summary>
    public static class AuthorizationFlowWellKnownUrls
    {
        /// <summary>
        /// The github login page request url.
        /// </summary>
        public const string GitHubLoginRequestPageUrl = "https://github.com/login?return_to=%2Flogin%2Foauth%2Fauthorize%3Fclient_id%3De865e74c1d0a3e66003c%26redirect_uri%3Dhttps%253A%252F%252Fgitter.im%252Flogin%252Fcallback%26response_type%3Dcode%26scope%3Duser%253Aemail%252Cread%253Aorg%26state%3D9bff6fdc2b0f2f3188676f70fe2a5316a28518fca75e2af0e6b5ddb0b6a08b34";

        /// <summary>
        /// The github home page url.
        /// </summary>
        public const string GitHubHomePageUrl = "https://github.com/";

        /// <summary>
        /// The authorization request page url.
        /// </summary>
        public const string AuthorizationRequestPageUrl = "https://gitter.im/login/oauth/authorize?client_id=" + AppInfo.ClientId + "&response_type=code&redirect_uri=" + CallBackUrl;

        /// <summary>
        /// The callback url.
        /// </summary>
        public const string CallBackUrl = "http://localhost:7000/login/callback";
    }
}