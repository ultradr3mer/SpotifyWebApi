namespace SpotifyWebApi.Api
{
  using System;

  using SpotifyWebApi.Business;
  using SpotifyWebApi.Model.Auth;

  /// <summary>
  /// The <see cref="BaseApi" /> used for all the other APIs.
  /// </summary>
  public abstract class BaseApi
  {
    #region Fields

    /// <summary>
    /// Gets the base spotify URI
    /// </summary>
    protected const string BaseUri = "https://api.spotify.com/v1/";

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseApi" /> class.
    /// </summary>
    /// <param name="token">A valid <see cref="Token" />.</param>
    protected BaseApi(Token token = null)
    {
      if (token == null)
      {
        return;
      }

      // Validate token
      Validation.ValidateToken(token);
      this.Token = token;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the <see cref="Token" />.
    /// </summary>
    protected Token Token { get; }

    #endregion

    #region Methods

    /// <summary>
    /// An helper function to add a device id at the end of a query string.
    /// </summary>
    /// <param name="sign">The sign to add, usually '&amp;' or '?'.</param>
    /// <param name="deviceId">The device id string to add.</param>
    /// <returns>A new query containing the sign with the market.</returns>
    protected static string AddDeviceId(string sign, string deviceId)
    {
      return string.IsNullOrEmpty(deviceId) ? string.Empty : $"{sign}device_id=" + deviceId;
    }

    /// <summary>
    /// An helper function to add a market code at the end of a query string.
    /// </summary>
    /// <param name="sign">The sign to add, usually '&amp;' or '?'.</param>
    /// <param name="market">The market string to add.</param>
    /// <returns>A new query containing the sign with the market.</returns>
    protected static string AddMarketCode(string sign, string market)
    {
      return string.IsNullOrEmpty(market) ? string.Empty : $"{sign}market=" + market;
    }

    /// <summary>
    /// Makes a Spotify uri from the <see cref="BaseUri" /> and the provided <paramref name="relativeUrl" />.
    /// </summary>
    /// <param name="relativeUrl">The relative URL.</param>
    /// <returns>The full request uri.</returns>
    protected static Uri MakeUri(string relativeUrl)
    {
      if (relativeUrl.StartsWith("/"))
      {
        relativeUrl = relativeUrl.Substring(1);
      }

      return new Uri(BaseApi.BaseUri + relativeUrl);
    }

    #endregion
  }
}