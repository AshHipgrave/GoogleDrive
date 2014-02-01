using System;
using System.Web;
using System.Collections.Specialized;

using DotNetOpenAuth.OAuth2;
using DotNetOpenAuth.Messaging;

using Google.Apis.Authentication;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace SxGoogle
{
    public class DriveAuthentication
    {
        internal static string SavedRefreshToken { get; set; }

        private const string CLIENT_ID = "CLIENT-ID-HERE";
        private const string CLIENT_SECRET = "CLIENT-SECRET-HERE";
        private const string REDIRECT_URI = "REDIRECT-URI-HERE";

        private static readonly string[] SCOPES =
        {
            "https://www.googleapis.com/auth/drive.file",
            "https://www.googleapis.com/auth/userinfo.email",
            "https://www.googleapis.com/auth/userinfo.profile",
            "https://www.googleapis.com/auth/drive.install"
        };

        public static string GetAuthorisationUrl(string emailAddress, string State)
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
            {
                ClientIdentifier = CLIENT_ID
            };

            IAuthorizationState authorisationState = new AuthorizationState(SCOPES);
            authorisationState.Callback = new Uri(REDIRECT_URI);

            UriBuilder builder = new UriBuilder(provider.RequestUserAuthorization(authorisationState));
            NameValueCollection queryParameters = HttpUtility.ParseQueryString(builder.Query);

            queryParameters.Set("access_type", "offline");
            queryParameters.Set("approval_prompt", "force");
            queryParameters.Set("user_id", emailAddress);
            queryParameters.Set("state", State);

            builder.Query = queryParameters.ToString();
            return builder.Uri.ToString();
        }

        public static IAuthorizationState ExchangeCode(string AuthorisationCode)
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description, CLIENT_ID, CLIENT_SECRET);
            IAuthorizationState state = new AuthorizationState();
            state.Callback = new Uri(REDIRECT_URI);

            try
            {
                state = provider.ProcessUserAuthorization(AuthorisationCode, state);
                return state;
            }
            catch (ProtocolException)
            {
                throw new CodeExchangeException(null);
            }
        }

        internal static IAuthenticator UseSavedAuthentication()
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
            {
                ClientIdentifier = CLIENT_ID,
                ClientSecret = CLIENT_SECRET
            };

            OAuth2Authenticator<NativeApplicationClient> auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetState);
            auth.LoadAccessToken();

            return auth;
        }

        internal static IAuthorizationState GetState(NativeApplicationClient arg)
        {
            IAuthorizationState state = new AuthorizationState(SCOPES);
            state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);

            state.RefreshToken = SavedRefreshToken;
            arg.RefreshToken(state);

            return state;
        }
    }
}
