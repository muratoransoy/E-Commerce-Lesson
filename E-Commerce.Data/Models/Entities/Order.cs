using E_Commerce.Data.Models.Entities.Common;
using E_Commerce.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data.Models.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState  OrderState { get; set; }

        public string Username { get; set; }
        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Neighbourhood { get; set; }
        public string PostalCode { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
}
