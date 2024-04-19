using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Abstract
{
    public interface IGenericRepository<Tentity> 
        where Tentity : class, new()
    {
        List<Tentity> GetAll(Expression<Func<Tentity,bool>> filter = null);
        Tentity Get(int id);
        Tentity Get(Expression<Func<Tentity, bool>> filter = null);
        void Add(Tentity tentity);
        void Update(Tentity tentity);
        void Delete(int id);
        void Delete(Tentity tentity);
    }
}
