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
    public Task<WebResponse> Next(string deviceId = null)
    {
      return ApiClient.PostAsync<object>(
        BaseApi.MakeUri($"me/player/next{BaseApi.AddDeviceId("?", deviceId)}"),
        null,
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> PausePlayback(string deviceId = null)
    {
      return ApiClient.PutAsync<object>(
        BaseApi.MakeUri($"me/player/pause{BaseApi.AddDeviceId("?", deviceId)}"),
        null,
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> Previous(string deviceId = null)
    {
      return ApiClient.PostAsync<object>(
        BaseApi.MakeUri($"me/player/previous{BaseApi.AddDeviceId("?", deviceId)}"),
        null,
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> Seek(int positionMs, string deviceId = null)
    {
      return ApiClient.PutAsync<object>(
        BaseApi.MakeUri($"me/player/seek?position_ms={positionMs}{BaseApi.AddDeviceId("&", deviceId)}"),
        null,
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> SetRepeat(RepeatState state, string deviceId = null)
    {
      return ApiClient.PutAsync<object>(
        BaseApi.MakeUri($"me/player/repeat?state={state.ToString().ToLower()}{BaseApi.AddDeviceId("&", deviceId)}"),
        null,
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> SetShuffle(bool state, string deviceId = null)
    {
      return ApiClient.PutAsync<object>(
        BaseApi.MakeUri($"me/player/shuffle?state={state.ToString().ToLower()}{BaseApi.AddDeviceId("&", deviceId)}"),
        null,
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> SetVolume(int volumePercent, string deviceId = null)
    {
      return ApiClient.PutAsync<object>(
        BaseApi.MakeUri($"me/player/volume?volume_percent={volumePercent}{BaseApi.AddDeviceId("&", deviceId)}"),
        null,
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> StartPlayback(string deviceId = null, SpotifyUri contextUri = null, List<SpotifyUri> uris = null, IPlaybackOffset offset = null)
    {
      return ApiClient.PutAsync<object>(
        BaseApi.MakeUri($"me/player/play{BaseApi.AddDeviceId("?", deviceId)}"),
        new
        {
          context_uri = contextUri?.FullUri,
          uris = uris?.Select(o => o.FullUri),
          offset
        },
        this.Token);
    }

    /// <inheritdoc />
    public Task<WebResponse> TransferPlayback(List<string> deviceId, bool? play = null)
    {
      return ApiClient.PutAsync<object>(
        BaseApi.MakeUri($"me/player"),
        new
        {
          device_ids = deviceId,
          play
        },
        this.Token);
    }

    #endregion
  }
}