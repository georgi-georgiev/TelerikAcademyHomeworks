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
    public class AlbumsController : ApiController
    {
        private IRepository<Album> albumRepository;

        public AlbumsController()
        {
            var context = new MusicStoreContext();
            this.albumRepository = new DbAlbumRepository(context);
        }

        public AlbumsController(IRepository<Album> repository)
        {
            this.albumRepository = repository;
        }

        // GET api/albums
        public IEnumerable<AlbumsModel> GetAllAlbums()
        {
            var albumEntities = this.albumRepository.All().ToList();

            var albumsModel =
                from albumEntity in albumEntities
                select new AlbumsModel()
                {
                    Id = albumEntity.Id,
                    Title = albumEntity.Title,
                    Producer = albumEntity.Producer,
                    Year = albumEntity.Year,
                    SongsCount = albumEntity.Songs.Count(),
                    ArtistsCount = albumEntity.Artists.Count()
                };

            if (albumsModel == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no items found"));
            }
            else
            {
                return albumsModel.ToList();
            }
        }

        // GET api/albums/5
        public AlbumsFullModel GetAlbumById(int id)
        {
            if (id <= 0)
            {
                throw new HttpResponseException(this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found"));
            }

            var albumEntity = this.albumRepository.Get(id);

            if (albumEntity == null)
            {
                var errResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found");
                throw new HttpResponseException(errResponse);
            }

            var albumModel = new AlbumsFullModel()
            {
                Id = albumEntity.Id,
                Title = albumEntity.Title,
                Producer = albumEntity.Producer,
                ArtistsCount = albumEntity.Artists.Count(),
                SongsCount = albumEntity.Songs.Count(),
                Songs = (
                from songs in albumEntity.Songs
                select new SongsModel()
                {
                    Id = songs.Id,
                    Title = songs.Title,
                    Year = songs.Year,
                    Genre = songs.Genre,
                    Artist = songs.Artist.Name,
                    AlbumsCount = songs.Albums.Count()
                }).ToList(),
                Artists = (
                from artists in albumEntity.Artists
                select new ArtistsModel()
                {
                    Id = artists.Id,
                    Name = artists.Name,
                    DateOfBirth = artists.DateOfBirth,
                    Country = artists.Country,
                    SongsCount = artists.Songs.Count(),
                    AlbumsCount = artists.Albums.Count()
                }).ToList()

            };

            return albumModel;
        }

        // POST api/albums
        public HttpResponseMessage PostAlbum(Album model)
        {
            if (model.Producer == null || model.Year == null || model.Title == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "need to add producer, year and title");
            }
            else
            {
                var entity = this.albumRepository.Add(model);

                var response =
                    Request.CreateResponse(HttpStatusCode.Created, entity);

                response.Headers.Location = new Uri(Url.Link("DefaultApi",
                    new { id = entity.Id }));
                return response;
            }
        }

        //// PUT api/albums/5
        public HttpResponseMessage PutAlbum(int id, Album model)
        {
            if (id < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "no items found");
            }
            else if (model.Producer == null || model.Year == null || model.Title == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "need to add producer, year and title");
            }
            else
            {
                this.albumRepository.Update(id, model);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE api/albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            if (id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "no item found");
            }

            var albumEntity = this.albumRepository.Get(id);

            if (albumEntity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "no item found");
            }
            else
            {
                this.albumRepository.Delete(albumEntity);

                return Request.CreateResponse(HttpStatusCode.OK,
                    "Successfully deleted");
            }
        }
    }
}
