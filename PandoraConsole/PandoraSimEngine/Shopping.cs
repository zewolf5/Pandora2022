using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraSimEngine
{
    internal class Shopping
    {
        List<string> _products = new List<string>();
        public Shopping()
        {
            var products = @"produktliste.csv";
            foreach (var item in File.ReadAllLines(products))
            {
                var product = item.Split(';')[0].Trim('[', ']');
                _products.Add(product);
            }
        }

        public (string product, float price) GetProduct()
        {
            var rnd = new Random();
            var item = rnd.Next(_products.Count);
            return (_products[item], rnd.Next(100000) + 10);
        }
    }
}
