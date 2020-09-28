using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyWebApi.Model.Uri;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyWebApiTest.Api
{
  [TestClass]
  public class PlaylistTest : TestBase
  {
    [TestMethod]
    public void GetPlaylistTest()
    {
      var test = this.Api.Playlist.GetPlaylist(SpotifyUri.Make("spotify:playlist:3ewZM7pLkkmbqULVsRZwnM")).Result;
    }
  }
}
