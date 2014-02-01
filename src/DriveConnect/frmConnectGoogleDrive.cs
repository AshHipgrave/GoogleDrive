using System.Linq;
using System.Windows.Forms;

using SxGoogle;
using DotNetOpenAuth.OAuth2;

namespace DriveConnect
{
    public partial class frmConnectGoogleDrive : Form
    {
        //TODO: Refactor This Class, See:
        //http://stackoverflow.com/questions/4002847/oauth-with-verification-in-net

        private static string token;

        public frmConnectGoogleDrive()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string authUrl = DriveAuthentication.GetAuthorisationUrl("", "");
            webDrive.Navigate(authUrl);
        }

        private void webDrive_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (webDrive == null || webDrive.Document == null || webDrive.Document.Title == null) return;

                if ((webDrive.Document.Title.Trim().ToLower().Contains("success")) && webDrive.Document.Body != null)
                {
                    int num = webDrive.Document.Body.InnerHtml.LastIndexOf("value=");

                    if (num <= 0) return;

                    token = webDrive.Document.Body.InnerHtml.Substring(num).Replace("value=", string.Empty).Replace("\">", string.Empty).TrimStart(new[] { '"' });

                    if (token.Contains(" "))
                    {
                        token = token.Split(new[] { ' ' }).First();
                    }

                    GetCode();
                }
                else
                {
                    if (!webDrive.Document.Title.Trim().ToLower().Contains("access_denied") &&
                        !webDrive.Document.Title.Trim().ToLower().Contains("error")) return;

                    token = null;
                    Close();
                }
            }
            catch
            {
                token = null;
                Close();
            }
        }

        private void GetCode()
        {
            IAuthorizationState state = DriveAuthentication.ExchangeCode(token);

            GDriveSettingsManager.ApiUserKey = state.AccessToken;
            GDriveSettingsManager.ApiUserSecret = state.RefreshToken;

            Close();
        }
    }
}
