using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASP.NET_Web_Api_CRUD.Models;
using MusicStore.Client.Models;
using MusicStore.DataLayer;
using MusicStore.Models;
using MusicStore.Repositories;

namespace MusicStore.Client.Controllers
{
    public class SongsController : ApiController
    {
        private IRepository<Song> songRepository;

        public SongsController()
        {
            var context = new MusicStoreContext();
            this.songRepository = new DbSongRepository(context);
        }

        public SongsController(IRepository<Song> repository)
        {
            this.songRepository = repository;
        }

        // GET api/albums
        public IEnumerable<SongsModel> GetAllSongs()
        {
            var songEntities = this.songRepository.All().ToList();

            var songsModel =
                from songEntity in songEntities
                select new SongsModel()
                {
                    Id = songEntity.Id,
                    Title = songEntity.Title,
                    Year = songEntity.Year,
                    Genre = songEntity.Genre,
                    Artist = songEntity.Artist.Name,
                    AlbumsCount = songEntity.Albums.Count()
                };

            if (songsModel == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no items found"));
            }
            else
            {
                return songsModel.ToList();
            }
        }

        // GET api/albums/5
        public SongsFullModel GetSongById(int id)
        {
            if (id <= 0)
            {
                throw new HttpResponseException(this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found"));
            }

            var songEntity = this.songRepository.Get(id);

            if (songEntity == null)
            {
                var errResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found");
                throw new HttpResponseException(errResponse);
            }

            var songModel = new SongsFullModel()
            {
                Id = songEntity.Id,
                Title = songEntity.Title,
                Year = songEntity.Year,
                Genre = songEntity.Genre,
                Artist = songEntity.Artist.Name,
                AlbumsCount = songEntity.Albums.Count(),
                Albums = (
                from albums in songEntity.Albums
                select new AlbumsModel()
                {
                    Id = albums.Id,
                    Title = albums.Title,
                    Producer = albums.Producer,
                    Year = albums.Year,
                    SongsCount = albums.Songs.Count(),
                    ArtistsCount = albums.Artists.Count()
                }).ToList()
            };

            return songModel;
        }

        // POST api/albums
        public HttpResponseMessage PostSong(Song model)
        {
            if (model.Artist == null || model.Title == null || model.Genre == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "need to add artist, title and genre");
            }
            else
            {
                var entity = this.songRepository.Add(model);

                var response =
                    Request.CreateResponse(HttpStatusCode.Created, entity);

                response.Headers.Location = new Uri(Url.Link("DefaultApi",
                    new { id = entity.Id }));
                return response;
            }
        }

        //// PUT api/albums/5
        public HttpResponseMessage PutSong(int id, Song model)
        {
            if (id < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "no items found");
            }
            else if (model.Artist == null || model.Title == null || model.Year == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "need to add artist, year and title");
            }
            else
            {
                this.songRepository.Update(id, model);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE api/albums/5
        public HttpResponseMessage DeleteSong(int id)
        {
            if (id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "no item found");
            }

            var songEntity = this.songRepository.Get(id);

            if (songEntity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "no item found");
            }
            else
            {
                this.songRepository.Delete(songEntity);

                return Request.CreateResponse(HttpStatusCode.OK,
                    "Successfully deleted");
            }
        }
    }
}
