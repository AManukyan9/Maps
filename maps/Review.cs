using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maps
{
    class Review
    {
        private string rev;
        private decimal rating;
        private string user;
        private Building building;

        public Review(string rev, decimal rating, string user, Building building)
        {
            this.rev = rev;
            this.rating = rating;
            this.user = user;
            this.building = building;
        }

        public string Rev { get { return this.rev; } }
        public decimal Rating { get { return this.rating; } }
        public string User { get { return this.user; } }
    }
}
