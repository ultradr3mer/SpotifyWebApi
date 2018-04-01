namespace SpotifyWebApiTest.Api
{
  using System.Collections.Generic;
  using System.Linq;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using SpotifyWebApi.Model;
  using SpotifyWebApi.Model.Offset;
  using SpotifyWebApi.Model.Uri;

  /// <summary>
  /// The <see cref="AlbumTest" />.
  /// </summary>
  [TestClass]
  public class PlayerTest : TestBase
  {
    #region Methods

    /// <summary>
    /// The albums test.
    /// </summary>
    [TestMethod]
    public void GetAlbumsTest()
    {
    }

    /// <summary>
    /// The album tracks test.
    /// </summary>
    [TestMethod]
    public void GetAlbumTracksTest()
    {
    }

    /// <summary>
    /// The album test.
    /// </summary>
    [TestMethod]
    public void StartPlaybackTestUriOffset()
    {
      this.Api.Player.StartPlayback(
        null,
        SpotifyUri.Make("0sNOF9WDwhWunNAHPD3Baj", UriType.Album),
        null,
        new UriOffset
          {
            Uri = SpotifyUri.Make("2joHDtKFVDDyWDHnOxZMAX", UriType.Track).FullUri
          }).Wait();
    }

    /// <summary>
    /// The album test.
    /// </summary>
    [TestMethod]
    public void StartPlaybackTestPositionOffset()
    {
      this.Api.Player.StartPlayback(
        null,
        SpotifyUri.Make("0sNOF9WDwhWunNAHPD3Baj", UriType.Album),
        null,
        new PositionOffset()
          {
            Position = 1
          }).Wait();
    }

    /// <summary>
    /// The album test.
    /// </summary>
    [TestMethod]
    public void StartPlaybackTestWithUris()
    {
      this.Api.Player.StartPlayback(
        null,
        null,
        new List<SpotifyUri>
          {
            SpotifyUri.Make("2joHDtKFVDDyWDHnOxZMAX", UriType.Track),
            SpotifyUri.Make("6ClztHzretmPHCeiNqR5wD", UriType.Track),
            SpotifyUri.Make("2tVHvZK4YYzTloSCBPm2tg", UriType.Track)
          },
        new UriOffset
          {
            Uri = SpotifyUri.Make("2joHDtKFVDDyWDHnOxZMAX", UriType.Track).FullUri
          }).Wait();
    }


    /// <summary>
    /// The album test.
    /// </summary>
    [TestMethod]
    public void TransferPlaybackToFirstDevice()
    {
      var devices = this.Api.Player.GetAvailableDevices().Result;

      this.Api.Player.TransferPlayback(
        new List<Device>
          {
            devices.Devices[0]
          },
        true).Wait();
    }

    /// <summary>
    /// The album test.
    /// </summary>
    [TestMethod]
    public void TransferPlaybackToSecondDevice()
    {
      var devices = this.Api.Player.GetAvailableDevices().Result;

      this.Api.Player.TransferPlayback(
        new List<Device>
          {
            devices.Devices[1]
          },
        true).Wait();
    }

    #endregion
  }
}