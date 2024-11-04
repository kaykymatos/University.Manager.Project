using IdentityModel.Client;
using IdentityModel.OidcClient.Browser;
using System.Diagnostics;

namespace University.Manager.Project.Mobile.MauiAppUniversity
{
    public class MauiAuthenticationBrowser : IdentityModel.OidcClient.Browser.IBrowser
    {
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await WebAuthenticator.Default.AuthenticateAsync(
                    new Uri(options.StartUrl), new Uri(options.EndUrl));

                return new BrowserResult
                {
                    Response = result?.ToString()
                };
            }
            catch (Exception ex)
            {
                return new BrowserResult
                {
                    ResultType = BrowserResultType.UserCancel,
                    Error = ex.Message
                };
            }
        }
    }
}
