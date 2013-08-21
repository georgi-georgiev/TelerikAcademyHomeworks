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
    public class ArtistsController : ApiController
    {
        private IRepository<Artist> artistRepository;

        public ArtistsController()
        {
            var context = new MusicStoreContext();
            this.artistRepository = new DbArtistRepository(context);
        }

        public ArtistsController(IRepository<Artist> repository)
        {
            this.artistRepository = repository;
        }

        // GET api/albums
        public IEnumerable<ArtistsModel> GetAllArtists()
        {
            var artistEntities = this.artistRepository.All().ToList();

            var artistsModel =
                from artistEntity in artistEntities
                select new ArtistsModel()
                {
                    Id = artistEntity.Id,
                    Name = artistEntity.Name,
                    DateOfBirth = artistEntity.DateOfBirth,
                    Country = artistEntity.Country,
                    SongsCount = artistEntity.Songs.Count(),
                    AlbumsCount = artistEntity.Albums.Count()
                };

            if (artistsModel == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no items found"));
            }
            else
            {
                return artistsModel.ToList();
            }
        }

        // GET api/albums/5
        public ArtistFullModel GetArtistById(int id)
        {
            if (id <= 0)
            {
                throw new HttpResponseException(this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found"));
            }

            var artistEntity = this.artistRepository.Get(id);

            if (artistEntity == null)
            {
                var errResponse = this.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "no item found");
                throw new HttpResponseException(errResponse);
            }

            var artistModel = new ArtistFullModel()
            {
                Id = artistEntity.Id,
                Name = artistEntity.Name,
                DateOfBirth = artistEntity.DateOfBirth,
                Country = artistEntity.Country,
                SongsCount = artistEntity.Songs.Count(),
                AlbumsCount = artistEntity.Albums.Count(),
                Songs = (
                from songs in artistEntity.Songs
                select new SongsModel()
                {
                    Id = songs.Id,
                    Title = songs.Title,
                    Year = songs.Year,
                    Genre = songs.Genre,
                    Artist = songs.Artist.Name,
                    AlbumsCount = songs.Albums.Count()
                }).ToList(),
                Albums = (
                from albums in artistEntity.Albums
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

            return artistModel;
        }

        // POST api/albums
        public HttpResponseMessage PostArtist(Artist model)
        {
            if (model.DateOfBirth == null || model.Country == null || model.Name == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "need to add name, country and date of birth");
            }
            else
            {
                var entity = this.artistRepository.Add(model);

                var response =
                    Request.CreateResponse(HttpStatusCode.Created, entity);

                response.Headers.Location = new Uri(Url.Link("DefaultApi",
                    new { id = entity.Id }));
                return response;
            }
        }

        //// PUT api/albums/5
        public HttpResponseMessage PutArtist(int id, Artist model)
        {
            if (id < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "no items found");
            }
            else if (model.Name == null || model.Country == null || model.DateOfBirth == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "need to add name, country and date of birth");
            }
            else
            {
                this.artistRepository.Update(id, model);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE api/albums/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            if (id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "no item found");
            }

            var artistEntity = this.artistRepository.Get(id);

            if (artistEntity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "no item found");
            }
            else
            {
                this.artistRepository.Delete(artistEntity);

                return Request.CreateResponse(HttpStatusCode.OK,
                    "Successfully deleted");
            }
        }
    }
}
