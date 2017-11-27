namespace VideoStore
{
	public enum PriceCode
	{
		Regular,
		NewRelease,
		Childrens
	}

	public class Movie
	{
        public string Title { get; set; }
        public PriceCode PriceCode { get; set; }

		public Movie(string title, PriceCode priceCode)
		{
            Title = title;
            PriceCode = priceCode;
		}
	}
}
