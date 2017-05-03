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
		private int ratingCount;
		private Address address;
		private string website;
		private string number;
		private string name;
		private decimal[] stars = new decimal[5];
		private decimal rating;
		private int visitors;
		private decimal popularityRating;
		private DateTime opening;
		private DateTime closing;
		public Building(Address address, string website, string number, DateTime opening, DateTime closing)
		{
			this.address = address;
			this.website = website;
			this.number = number;
			this.opening = opening;
			this.closing = closing;
            Maps.AddBuilding(this);
		}
		
		public Building(string name, Address address, string website, string number)
		{
			this.name = name;
			this.address = address;
			this.website = website;
			this.number = number;
		}

		public void AddRating(int star)
		{
			switch (star)
			{
				case 1:
					this.stars[0]++;
					break;
				case 2:
					this.stars[1]++;
					break;
				case 3:
					this.stars[2]++;
					break;
				case 4:
					this.stars[3]++;
					break;
				case 5:
					this.stars[4]++;
					break;
				default:
					throw new ArgumentException("Can't give more than 5 stars");
			}
			this.AverageRating();
			this.PopularityCount();
			this.ratingCount++;
		}

		public void AddVisitors(int visitors)
		{
			this.visitors += visitors;
			this.PopularityCount();
		}

		public override string ToString()
		{
			if(this.name == ""){
				return "Building";
			} else {
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
			this.popularityRating = this.visitors * this.rating;
		}

		private void AverageRating()
		{
			this.rating = ((this.stars[0] * 1) + (this.stars[1] * 2) + (this.stars[2] * 3) + (this.stars[3] * 4) + (this.stars[4] * 5)) /
				(this.stars[0] + this.stars[1] + this.stars[2] + this.stars[3] + this.stars[4]);
		}

		public Address Address { get { return this.address; } }
		public int RatingCount { get { return this.ratingCount; } }
		public string Number { get { return this.number; } }
		public string Website { get { return this.website; } }
		public decimal Rating { get { return this.rating; } }
		public int Visitors { get { return this.visitors; } }
		public decimal Popularity { get { return this.popularityRating; } }
		public DateTime Opening { get { return this.opening; } }
		public DateTime Closing { get { return this.closing; } }


	}
}
