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
        public const string GitHubLoginRequestPageUrl = "https://github.com/login";

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