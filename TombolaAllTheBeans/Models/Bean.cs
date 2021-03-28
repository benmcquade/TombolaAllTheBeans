using System;

namespace TombolaAllTheBeans.Models
{
    public class Bean
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public string Aroma { get; set; }

        public string Colour { get; set; }

        public float Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateDisplayed { get; set; }
    }
}