using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace maps
{
    class Building : IComparable<Building>
    {
        private Address address;
        private string website;
        private string number;
        private string name;
        private Dictionary<string, Review> reviews = new Dictionary<string, Review>();
        private decimal rating;
        private decimal popularityRating;
        private DateTime opening;
        private DateTime closing;
        public Building(string name, Address address, string website, string number, DateTime opening, DateTime closing)
        {
            this.name = name;
            this.address = address;
            this.website = website;
            this.number = number;
            this.opening = opening;
            this.closing = closing;
        }

        public Building(string name, Address address, string website, string number)
        {
            this.name = name;
            this.address = address;
            this.website = website;
            this.number = number;
        }

        public void AddRating(Review rev)
        {
                if (reviews.ContainsKey(rev.Username))
                {
                    reviews.Remove(rev.Username);
                }
                reviews.Add(rev.Username, rev);
                this.AverageRating();
        }
        public override string ToString()
        {
            if (this.name == "")
            {
                return "Building";
            }
            else
            {
                return "Building " + this.name;
            }
        }

        public int CompareTo(Building other)
        {
            if (this.popularityRating < other.popularityRating)
                return -1;
            else if (this.popularityRating == other.popularityRating)
                return 0;
            else
                return 1;
        }

        private void PopularityCount()
        {
            this.popularityRating = this.rating;
        }

        private void AverageRating()
        {
            decimal c = 0;
            foreach(Review item in reviews.Values)
            {
                c += item.Rating;
            }
            this.rating = c / reviews.Count;
        }

        public string Name { get { return this.name; } }
        public Address Address { get { return this.address; } }
        public string Number { get { return this.number; } }
        public string Website { get { return this.website; } }
        public decimal Rating { get { return this.rating; } }
        public decimal Popularity { get { return this.popularityRating; } }
        public DateTime Opening { get { return this.opening; } }
        public DateTime Closing { get { return this.closing; } }
        public Dictionary<string, Review> Reviews { get { return this.reviews; } }
    }
}
