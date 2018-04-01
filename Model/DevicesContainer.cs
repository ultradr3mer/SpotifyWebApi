namespace SpotifyWebApi.Model
{
  using System.Collections.Generic;

  using Newtonsoft.Json;

  /// <summary>
  /// The user's available devices.
  /// </summary>
  public class DevicesContainer
  {
    #region Properties

    /// <summary>
    /// Gets or sets the devices.
    /// </summary>
    [JsonProperty("devices")]
    public List<Device> Devices { get; set; }

    #endregion
  }
}