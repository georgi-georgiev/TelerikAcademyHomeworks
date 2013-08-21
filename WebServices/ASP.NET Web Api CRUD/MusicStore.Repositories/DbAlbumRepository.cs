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
    public class DbAlbumRepository : IRepository<Album>
    {
        private DbContext dbContext;
        private DbSet<Album> entitySet;

        public DbAlbumRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Album>();
        }

        public Album Add(Album item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Album Update(int id, Album item)
        {
            var updatedAlbum = new Album()
            {
                Id = id,
                Title = item.Title,
                Year = item.Year,
                Producer = item.Producer
            };

            this.entitySet.Add(updatedAlbum);
            var entry = dbContext.Entry(updatedAlbum);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();

            return updatedAlbum;
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            Delete(entity);
        }

        public void Delete(Album item)
        {
            this.entitySet.Remove(item);
            this.dbContext.SaveChanges();
        }

        public Album Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Album> All()
        {
            return this.entitySet;
        }

        public IQueryable<Album> Find(System.Linq.Expressions.Expression<Func<Album, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
