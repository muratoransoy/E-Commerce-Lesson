using E_Commerce.Business.Abstract;
using E_Commerce.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Abstract
{
    public interface IProductDAL : IGenericRepository<Product>
    {
    }
}
