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
				result += "\t" + each.Movie.Title + "\t" + thisAmount + "\n";
				totalAmount += thisAmount;
			}

			// Add footer lines
			result += "Amount owed is " + totalAmount + "\n";
			result += "You earned " + frequentRenterPoints + " frequent renter points.";
			return result;
		}

        public string HtmlStatement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "<H1>Rental record for <EM>" + Name + "</EM></H1>\n";
            foreach (Rental each in Rentals)
            {
                double thisAmount = 0;

                // Determine amounts for each line
                switch (each.Movie.PriceCode)
                {
                    case PriceCode.Regular:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                        {
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        }
                        break;

                    case PriceCode.NewRelease:
                        thisAmount += each.DaysRented * 3;
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
                    frequentRenterPoints++;
                }

                // Show figures for this rental
                result += each.Movie.Title + ": " + thisAmount + "<BR>\n";
                totalAmount += thisAmount;
            }

            // Add footer lines
            result += "<P>Amount owed is <EM>" + totalAmount + "</EM></P>\n";
            result += "<P>You earned <EM>" + frequentRenterPoints + "</EM> frequent renter points.</P>";
            return result;
        }
    }
}
