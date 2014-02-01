using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace SxGoogle
{
    internal class StoredStateClient : NativeApplicationClient
    {
        public IAuthorizationState State { get; private set; }

        public StoredStateClient(AuthorizationServerDescription AuthServer, string ClientId, string ClientSecret, IAuthorizationState AuthState)
            : base(AuthServer, ClientId, ClientSecret)
        {
            State = AuthState;
        }

        public static IAuthorizationState GetState(StoredStateClient provider)
        {
            return provider.State;
        }
    }
}