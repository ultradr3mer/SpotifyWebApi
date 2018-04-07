namespace SpotifyWebApiTest.Api
{
  using System.Collections.Generic;
  using System.Linq;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using SpotifyWebApi.Model;
  using SpotifyWebApi.Model.Enum;
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
    /// Start the pause playback test.
    /// </summary>
    [TestMethod]
    public void PausePlayback()
    {
      this.Api.Player.PausePlayback().Wait();
    }

    /// <summary>
    /// Start the resume playback test.
    /// </summary>
    [TestMethod]
    public void ResumePlayback()
    {
      this.Api.Player.StartPlayback().Wait();
    }

    /// <summary>
    /// Start the next track test.
    /// </summary>
    [TestMethod]
    public void NextTrack()
    {
      this.Api.Player.Next().Wait();
    }


    /// <summary>
    /// Start the next previous test.
    /// </summary>
    [TestMethod]
    public void PreviousTrack()
    {
      this.Api.Player.Previous().Wait();
    }


    /// <summary>
    /// Start the seek test.
    /// </summary>
    [TestMethod]
    public void Seek()
    {
      this.Api.Player.Seek(60000).Wait();
    }

    /// <summary>
    /// Starts the set repeat to off test.
    /// </summary>
    [TestMethod]
    public void SetRepeatToOff()
    {
      this.Api.Player.SetRepeat(RepeatState.Off).Wait();
    }

    /// <summary>
    /// Starts the set repeat to context test.
    /// </summary>
    [TestMethod]
    public void SetRepeatToContext()
    {
      this.Api.Player.SetRepeat(RepeatState.Context).Wait();
    }


    /// <summary>
    /// Starts the set repeat to track test.
    /// </summary>
    [TestMethod]
    public void SetRepeatToTrack()
    {
      this.Api.Player.SetRepeat(RepeatState.Track).Wait();
    }

    /// <summary>
    /// Starts the turn shuffle off test.
    /// </summary>
    [TestMethod]
    public void TurnShuffleOff()
    {
      this.Api.Player.SetShuffle(false).Wait();
    }

    /// <summary>
    /// Starts the turn shuffle on test.
    /// </summary>
    [TestMethod]
    public void TurnShuffleOn()
    {
      this.Api.Player.SetShuffle(true).Wait();
    }

    /// <summary>
    /// Starts the set volume to 50 percent test.
    /// </summary>
    [TestMethod]
    public void SetVolumeTo50Percent()
    {
      this.Api.Player.SetVolume(50).Wait();
    }

    /// <summary>
    /// Starts the set volume to 100 percent test.
    /// </summary>
    [TestMethod]
    public void SetVolumeTo100Percent()
    {
      this.Api.Player.SetVolume(100).Wait();
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