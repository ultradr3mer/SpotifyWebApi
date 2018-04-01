namespace SpotifyWebApi.Api.Player
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  using SpotifyWebApi.Business;
  using SpotifyWebApi.Model;
  using SpotifyWebApi.Model.Auth;
  using SpotifyWebApi.Model.Enum;
  using SpotifyWebApi.Model.Offset;
  using SpotifyWebApi.Model.Uri;

  /// <summary>
  ///   The <see cref="PlayerApi" />.
  /// </summary>
  public class PlayerApi : BaseApi, IPlayerApi
  {
    #region Constructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="PlayerApi" /> class.
    /// </summary>
    /// <param name="token">A valid <see cref="Token" />.</param>
    public PlayerApi(Token token)
      : base(token)
    {
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    public async Task<DevicesContainer> GetAvailableDevices()
    {
      var r = await ApiClient.GetAsync<DevicesContainer>(BaseApi.MakeUri("me/player/devices"), this.Token);

      if (r.Response is DevicesContainer res)
      {
        return res;
      }

      return new DevicesContainer();
    }

    /// <inheritdoc />
    public async Task<CurrentlyPlaying> GetCurrentlyPlaying(string market = "")
    {
      var r = await ApiClient.GetAsync<CurrentlyPlaying>(
                BaseApi.MakeUri($"me/player/currently-playing{BaseApi.AddMarketCode("?", market)}"),
                this.Token);

      if (r.Response is CurrentlyPlaying res)
      {
        return res;
      }

      return new CurrentlyPlaying();
    }

    /// <inheritdoc />
    public async Task<CurrentlyPlayingContext> GetCurrentlyPlayingContext(string market = "")
    {
      var r = await ApiClient.GetAsync<CurrentlyPlayingContext>(
                BaseApi.MakeUri($"me/player{BaseApi.AddMarketCode("?", market)}"),
                this.Token);

      if (r.Response is CurrentlyPlayingContext res)
      {
        return res;
      }

      return new CurrentlyPlayingContext();
    }

    /// <inheritdoc />
    public Task Next(Device device = null)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task PausePlayback(Device device = null)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task Previous(Device device = null)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task Seek(int positionMs, Device device = null)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task SetRepeat(RepeatState state, Device device = null)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task SetShuffle(bool state, Device device = null)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task SetVolume(int volumePercent, Device device = null)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<WebResponse> StartPlayback(Device device = null, SpotifyUri contextUri = null, List<SpotifyUri> uris = null, IPlaybackOffset offset = null)
    {
      return ApiClient.PutAsync<FullPlaylist>(
        BaseApi.MakeUri($"me/player/play{BaseApi.AddDeviceId("?", device?.Id)}"),
        new
        {
          context_uri = contextUri?.FullUri,
          uris = uris?.Select(o => o.FullUri),
          offset
        },
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> TransferPlayback(List<Device> devices, bool? play = null)
    {
      return ApiClient.PutAsync<FullPlaylist>(
        BaseApi.MakeUri($"me/player"),
        new
        {
          device_ids = devices?.Select(o => o.Id),
          play
        },
        this.Token);
    }

    #endregion
  }
}