using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyWebApi;
using SpotifyWebApi.Auth;
using SpotifyWebApi.Model.Auth;
using SpotifyWebApi.Model.Enum;

namespace SpotifyWebApiTest.TestInitialization
{
  namespace Spotify.Services
  {
    internal class ConnectionService
    {
      #region Fields

      private const string ApiParameterFileName = "ApiParameter.json";

      private readonly AuthParameters apiParameter;

      #endregion

      #region Constructors

      public ConnectionService()
      {
        this.apiParameter = this.GetApiParameter();
        var url = AuthorizationCode.GetUrl(this.apiParameter, "test");
        this.ConnectUrl = url;
      }

      #endregion

      #region Properties

      public string ConnectUrl { get; set; }

      #endregion

      #region Methods

      public static void OpenBrowser(string url)
      {
        // hack because of this: https://github.com/dotnet/corefx/issues/10361
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
          Process.Start(new ProcessStartInfo("cmd", $"/c start \"CmdWindowName\" \"{url}\"") {CreateNoWindow = true});
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
          Process.Start("xdg-open", url);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
          Process.Start("open", url);
        }
      }

      public async Task<Data> GetResponse()
      {
        var webServer = new TcpListener(IPAddress.Any, 8000);
        webServer.Start();

        ConnectionService.OpenBrowser(this.ConnectUrl);

        var s = await webServer.AcceptSocketAsync();

        var bReceive = new byte[2048];
        var i = s.Receive(bReceive, bReceive.Length, 0);

        // Convert Byte to String
        var sBuffer = Encoding.ASCII.GetString(bReceive);

        s.Shutdown(SocketShutdown.Both);
        webServer.Stop();

        var t = sBuffer.Split('?')[1].Split('&')[0].Split('=')[1];

        var token = AuthorizationCode.ProcessCallback(this.apiParameter, t, string.Empty);

        var api = new SpotifyWebApi.SpotifyWebApi(token);

        return new Data(token, api);
      }

      private AuthParameters GetApiParameter()
      {
        if (!File.Exists(ConnectionService.ApiParameterFileName))
        {
          var sampleParameter = new AuthParameters
          {
            Scopes = Scope.All,

            ClientId = "YourClientId",
            ClientSecret = "YourClientSecret",

            RedirectUri = "http://localhost:8000",
            ShowDialog = false
          };

          var sampleJson = JsonConvert.SerializeObject(sampleParameter);

          using (var writer = File.CreateText(ConnectionService.ApiParameterFileName))
          {
            writer.Write(sampleJson);
          }
        }

        string apiParameterJson = null;
        using (var reader = File.OpenText(ConnectionService.ApiParameterFileName))
        {
          apiParameterJson = reader.ReadToEnd();
        }

        var apiParameters = JsonConvert.DeserializeObject<AuthParameters>(apiParameterJson);

        return apiParameters;
      }

      #endregion

      #region NestedTypes

      public class Data
      {
        #region Constructors

        public Data(Token token, ISpotifyWebApi api)
        {
          this.Token = token;
          this.Api = api;
        }

        #endregion

        #region Properties

        public ISpotifyWebApi Api { get; }
        public Token Token { get; }

        #endregion
      }

      #endregion
    }
  }
}