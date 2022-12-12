using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraSimEngine
{
    internal class Shopping
    {
        List<(string, string, float)> _products = new List<(string, string, float)>();
        public Shopping()
        {
            var products = @"produktliste.csv";
            foreach (var item in File.ReadAllLines(products, Encoding.GetEncoding("ISO-8859-1")))
            {
                var parts = item.Split(';');

                _products.Add((parts[0].Trim('[', ']'), parts[1].Trim('[', ']'), float.Parse(parts[2].Trim('[', ']'))));
            }
        }

        public (string product, string description, float price) GetProduct()
        {
            var rnd = new Random();
            var item = rnd.Next(_products.Count);
            return (_products[item].Item1, _products[item].Item2, _products[item].Item3);
        }
    }
}
