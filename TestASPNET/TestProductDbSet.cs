using System;
using System.Linq;
using ASPNET.Models;

namespace ASPNET.Tests
{
    class TestProductDbSet : TestDbSet<Product>
    {
        public override Product Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
        }
    }
}