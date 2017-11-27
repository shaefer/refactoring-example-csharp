using System.Collections.Generic;

namespace VideoStore
{
	public class Customer
	{
		public string Name { get; set; }
		public List<Rental> Rentals = new List<Rental>();

		public Customer(string name)
		{
			Name = name;
		}

		public void AddRental(Rental rental)
		{
			Rentals.Add(rental);
		}

		public string Statement()
		{
			double totalAmount = 0;
			int frequentRenterPoints = 0;
			string result = "Rental record for " + Name + "\n";
			foreach ( Rental each in Rentals )
			{
				double thisAmount = 0;

				// Determine amounts for each line
				switch(each.Movie.PriceCode)
				{
					case PriceCode.Regular:
						thisAmount += 2;
						if (each.DaysRented > 2)
						{
							thisAmount += (each.DaysRented - 2) * 1.5;
						}
						break;

					case PriceCode.NewRelease:
						thisAmount += each.DaysRented *3;
						break;

					case PriceCode.Childrens:
						thisAmount += 1.5;
						if (each.DaysRented > 3)
						{
							thisAmount = (each.DaysRented - 3) * 1.5;
						}
						break;
				}

				// Add frequent renter points
				frequentRenterPoints++;

				// Add bonus for a two-day new-release rental
				if ((each.Movie.PriceCode == PriceCode.NewRelease) && (each.DaysRented > 1))
				{
					frequentRenterPoints ++;
				}

				// Show figures for this rental
				result += "\t" + each.Movie.Title + "\t" + string.Format("{0:N1}", thisAmount) + "\n";
				totalAmount += thisAmount;
			}

			// Add footer lines
			result += "Amount owed is " + string.Format("{0:N1}", totalAmount) + "\n";
			result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points.";
			return result;
		}
	}
}
