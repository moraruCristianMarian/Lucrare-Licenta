using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public Restaurant(string name, string city)
        {
            Id = Guid.NewGuid();

            Name = name;
            City = city;
        }
    }
}
