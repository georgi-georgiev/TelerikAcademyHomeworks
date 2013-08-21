using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.DataLayer;
using MusicStore.Models;
using System.Data.Entity;
using System.Data;

namespace MusicStore.Repositories
{
    public class DbSongRepository : IRepository<Song>
    {
        private DbContext dbContext;
        private DbSet<Song> entitySet;

        public DbSongRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Song>();
        }

        public Song Add(Song item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Song Update(int id, Song item)
        {
            var updatedSong = new Song()
            {
                Id = id,
                Title = item.Title,
                Artist = item.Artist,
                Genre = item.Genre
            };

            this.entitySet.Add(updatedSong);
            var entry = dbContext.Entry(updatedSong);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();

            return updatedSong;
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            Delete(entity);
        }

        public void Delete(Song item)
        {
            this.entitySet.Remove(item);
            this.dbContext.SaveChanges();
        }

        public Song Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Song> All()
        {
            return this.entitySet;
        }

        public IQueryable<Song> Find(System.Linq.Expressions.Expression<Func<Song, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
