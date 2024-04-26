using E_Commerce.Business.Concreate;
using E_Commerce.DAL.Abstract;
using E_Commerce.Data.Context;
using E_Commerce.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Concreate
{
    public class CategoryDAL :GenericRepository<Category, E_CommerceContext>, ICategoryDAL
    {
    }
}
