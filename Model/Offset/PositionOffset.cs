namespace SpotifyWebApi.Model.Offset
{
  using Newtonsoft.Json;

  /// <summary>
  /// The offset inside a playing context as position.
  /// </summary>
  public class PositionOffset : IPlaybackOffset
  {
    #region Properties

    /// <summary>
    /// Gets or sets the position.
    /// </summary>
    [JsonProperty("position")]
    public int? Position { get; set; }

    #endregion
  }
}