namespace SpotifyWebApiTest.Api
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SpotifyWebApi;
    using SpotifyWebApi.Api;
    using SpotifyWebApi.Model.Auth;
    using SpotifyWebApi.Model.Uri;

    /// <summary>
    /// The <see cref="AlbumTest"/>.
    /// </summary>
    [TestClass]
    public class AlbumTest : TestBase
    {
        /// <summary>
        /// The album test.
        /// </summary>
        [TestMethod]
        public void GetAlbumTest()
        {
            var album = this.Api.Album.GetAlbum(SpotifyUri.Make("0sNOF9WDwhWunNAHPD3Baj", UriType.Album)).NonAsync();

            Assert.AreEqual("0sNOF9WDwhWunNAHPD3Baj", album.Id);
            Assert.AreEqual("Epic/Legacy", album.Label);
            Assert.AreEqual("She's So Unusual", album.Name);
            Assert.AreEqual(13, album.Tracks.Total);
            Assert.AreEqual("Cyndi Lauper", album.Artists.First().Name);
            Assert.AreEqual("2joHDtKFVDDyWDHnOxZMAX", album.Tracks.Items[1].Id);
            Assert.AreEqual("6ClztHzretmPHCeiNqR5wD", album.Tracks.Items[2].Id);
            Assert.AreEqual("2tVHvZK4YYzTloSCBPm2tg", album.Tracks.Items[3].Id);
        }

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
    }
}
