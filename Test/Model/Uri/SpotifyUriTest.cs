using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyWebApi.Model.Uri;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyWebApiTest.Model.Uri
{
  [TestClass]
  public class SpotifyUriTest
  {
    [TestMethod]
    public void MakeTest()
    {
      SpotifyUri.Make("spotify:playlist:3ewZM7pLkkmbqULVsRZwnM");
    }
  }
}
