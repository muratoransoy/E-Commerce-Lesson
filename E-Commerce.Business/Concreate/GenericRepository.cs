using E_Commerce.Business.Abstract;
using E_Commerce.Data.Context;
using E_Commerce.Data.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Concreate
{
    public class GenericRepository<Tentity, Tcontext> : IGenericRepository<Tentity>
        where Tentity : class, new()
        where Tcontext : IdentityDbContext<AppUser, AppRole, int>, new()
    {
        public void Add(Tentity entity)
        {
            using (var db = new Tcontext())
            {
                db.Set<Tentity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Tcontext())
            {
                var entity = db.Set<Tentity>().Find(id);
                db.Set<Tentity>().Remove(entity);
                db.SaveChanges();
            }
        }

        public void Delete(Tentity tentity)
        {
            using (var db = new Tcontext())
            {
                db.Entry(tentity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Tentity Get(int id)
        {
            using (var db = new Tcontext())
            {
                var entity = db.Set<Tentity>().Find(id);
                return entity;
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                var entity = db.Set<Tentity>().Find(filter);
                return entity;
            }
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return filter == null ? db.Set<Tentity>().ToList() : db.Set<Tentity>().Where(filter).ToList();
            }
        }

        public void Update(Tentity tentity)
        {
            using (var db = new Tcontext())
            {
                db.Entry(tentity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
