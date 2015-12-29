// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messages.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace GitMeet
{
    /// <summary>
    ///     The message params
    /// </summary>
    public static class Messages
    {
        /// <summary>
        ///     The token exchange message params.
        /// </summary>
        public static class TokenExchangeRequest
        {
            /// <summary>
            /// The grant type param name.
            /// </summary>
            public const string GrantType = "grant_type";

            /// <summary>
            /// The redirect uri param name.
            /// </summary>
            public const string RedirectUri = "redirect_uri";

            /// <summary>
            /// The code param name.
            /// </summary>
            public const string Code = "code";

            /// <summary>
            /// The client id param name.
            /// </summary>
            public const string ClientId = "client_id";

            /// <summary>
            /// The client secret param name.
            /// </summary>
            public const string ClientSecret = "client_secret";
        }

        /// <summary>
        /// The token exchange response params.
        /// </summary>
        public static class TokenExchangeResponse
        {
            /// <summary>
            /// The access token param name.
            /// </summary>
            public const string AccessToken = "access_token";
        }

        /// <summary>
        /// The grant types.
        /// </summary>
        public static class GrantType
        {
            /// <summary>
            /// The authorization code gran type value.
            /// </summary>
            public const string AuthorizationCode = "authorization_code";
        }
    }
}