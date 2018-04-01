namespace SpotifyWebApi.Model.Offset
{
  using Newtonsoft.Json;

  /// <summary>
  /// The offset inside a playing context as uri.
  /// </summary>
  public class UriOffset : IPlaybackOffset
  {
    #region Properties

    /// <summary>
    /// Gets or sets the uri.
    /// </summary>
    [JsonProperty("uri")]
    public string Uri { get; set; }

    #endregion
  }
}