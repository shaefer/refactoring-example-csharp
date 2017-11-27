using Xunit;

namespace VideoStore
{
    public class VideoStoreTests
    {

        private Customer customer;

        public VideoStoreTests()
        {
            customer = new Customer("Casey");
        }

  
        [Fact]
        public void testSingleNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("Thor: Ragnarok", PriceCode.NewRelease), 3));
            Assert.Equal("Rental record for Casey\n\tThor: Ragnarok\t9.0\nAmount owed is 9.0\nYou earned 2 frequent renter points.", customer.Statement());
        }

        [Fact]
        public void testDualNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("Thor: Ragnarok", PriceCode.NewRelease), 3));
            customer.AddRental(new Rental(new Movie("Justice League", PriceCode.NewRelease), 3));
            Assert.Equal("Rental record for Casey\n\tThor: Ragnarok\t9.0\n\tJustice League\t9.0\nAmount owed is 18.0\nYou earned 4 frequent renter points.", customer.Statement());
        }

        [Fact]
        public void testSingleChildrensStatement()
        {
            customer.AddRental(new Rental(new Movie("The Last Unicorn", PriceCode.Childrens), 3));
            Assert.Equal("Rental record for Casey\n\tThe Last Unicorn\t1.5\nAmount owed is 1.5\nYou earned 1 frequent renter points.", customer.Statement());
        }

        [Fact]
        public void testMultipleRegularStatement()
        {
            customer.AddRental(new Rental(new Movie("The Matrix", PriceCode.Regular), 1));
            customer.AddRental(new Rental(new Movie("6 Days 7 Nights", PriceCode.Regular), 2));
            customer.AddRental(new Rental(new Movie("The Man Who Knew Too Little", PriceCode.Regular), 3));

            Assert.Equal("Rental record for Casey\n\tThe Matrix\t2.0\n\t6 Days 7 Nights\t2.0\n\tThe Man Who Knew Too Little\t3.5\nAmount owed is 7.5\nYou earned 3 frequent renter points.", customer.Statement());
        }

    }
}
