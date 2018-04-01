using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyWebApi;
using SpotifyWebApi.Model.Auth;
using SpotifyWebApiTest.TestInitialization.Spotify.Services;

namespace SpotifyWebApiTest
{
  /// <summary>
  ///   The <see cref="TestBase" />.
  /// </summary>
  [TestClass]
  public class TestBase
  {
    #region Properties

    /// <summary>
    ///   The api.
    /// </summary>
    protected ISpotifyWebApi Api { get; set; }

    /// <summary>
    ///   The connection token.
    /// </summary>
    protected Token Token { get; set; }

    #endregion

    #region Methods

    /// <summary>
    ///   Initializes the connection for the test.
    /// </summary>
    [TestInitialize]
    public void BaseTestInit()
    {
      var service = new ConnectionService();
      var connectionData = service.GetResponse().Result;

      this.Token = connectionData.Token;
      this.Api = connectionData.Api;
    }

    #endregion
  }
}