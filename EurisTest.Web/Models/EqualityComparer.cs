using EURIS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EurisTest.Web.Models
{
    public class EqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
           
            if (x == null || y == null)
                return false;
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Product obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}