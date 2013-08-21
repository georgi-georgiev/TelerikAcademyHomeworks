using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using MusicStore.Client.Controllers;
using MusicStore.DataLayer;
using MusicStore.Repositories;

namespace MusicStore.Client.DependencyResolver
{
    public class DbDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            var dbContext = new MusicStoreContext();

            if (serviceType == typeof(AlbumsController))
            {
                var albumRepository = new DbAlbumRepository(dbContext);
                return new AlbumsController(albumRepository);
            }
            else if (serviceType == typeof(ArtistsController))
            {
                var artistRepository = new DbArtistRepository(dbContext);
                return new ArtistsController(artistRepository);
            }
            else if (serviceType == typeof(SongsController))
            {
                var songRepository = new DbSongRepository(dbContext);
                return new SongsController(songRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}