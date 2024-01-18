﻿namespace LicentaApp.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Cost { get; set; }


        public virtual ICollection<MenuProduct>? MenuProducts { get; set; }


        public Product(string name, string category, float cost)
        {
            Id = Guid.NewGuid();

            Name = name;
            Category = category;
            Cost = cost;
        }
    }
}
