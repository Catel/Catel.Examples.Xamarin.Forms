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
            /// </summary>
            public const string GrantType = "grant_type";

            /// <summary>
            /// </summary>
            public const string RedirectUri = "redirect_uri";

            /// <summary>
            /// </summary>
            public const string Code = "code";

            /// <summary>
            /// </summary>
            public const string ClientId = "client_id";

            /// <summary>
            /// </summary>
            public const string ClientSecret = "client_secret";
        }

        public static class TokenExchangeResponse
        {
            public const string AccessToken = "access_token";
        }

        public static class GrantType
        {
            public const string AuthorizationCode = "authorization_code";
        }
    }
}