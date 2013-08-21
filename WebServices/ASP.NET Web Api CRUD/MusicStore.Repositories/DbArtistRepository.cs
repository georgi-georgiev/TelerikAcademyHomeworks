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
    public class DbArtistRepository : IRepository<Artist>
    {
        private DbContext dbContext;
        private DbSet<Artist> entitySet;

        public DbArtistRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Artist>();
        }

        public Artist Add(Artist item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Artist Update(int id, Artist item)
        {
            var updatedArtist = new Artist()
            {
                Id = id,
                Name = item.Name,
                Country = item.Country,
                DateOfBirth = item.DateOfBirth
            };

            this.entitySet.Add(updatedArtist);
            var entry = dbContext.Entry(updatedArtist);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();

            return updatedArtist;
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            Delete(entity);
        }

        public void Delete(Artist item)
        {
            this.entitySet.Remove(item);
            this.dbContext.SaveChanges();
        }

        public Artist Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Artist> All()
        {
            return this.entitySet;
        }

        public IQueryable<Artist> Find(System.Linq.Expressions.Expression<Func<Artist, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
