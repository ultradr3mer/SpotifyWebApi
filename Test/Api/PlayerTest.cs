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
    /// The start playback test, with uri offset.
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
    /// The start playback test, with positional offset.
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
    /// The start playback test, with uris.
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
    /// The transfer playback to first device test.
    /// </summary>
    [TestMethod]
    public void TransferPlaybackToFirstDevice()
    {
      var devices = this.Api.Player.GetAvailableDevices().Result;

      this.Api.Player.TransferPlayback(
        new List<string>
          {
            devices.Devices[0].Id
          },
        true).Wait();
    }

    /// <summary>
    /// The transfer playback to secondary device test.
    /// </summary>
    [TestMethod]
    public void TransferPlaybackToSecondDevice()
    {
      var devices = this.Api.Player.GetAvailableDevices().Result;

      this.Api.Player.TransferPlayback(
        new List<string>
          {
            devices.Devices[1].Id
          },
        true).Wait();
    }

    /// <summary>
    /// The Get currently playing test.
    /// </summary>
    [TestMethod]
    public void GetCurrentlyPlaying()
    {
      var playing = this.Api.Player.GetCurrentlyPlaying().Result;
    }

    #endregion
  }
}