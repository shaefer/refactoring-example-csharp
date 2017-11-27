using Xunit;

namespace VideoStore
{
    public class VideoStoreTests
    {

        private Customer customer;

        public VideoStoreTests()
        {
            customer = new Customer("Fred");
        }

  
        [Fact]
        public void testSingleNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", PriceCode.NewRelease), 3));
            Assert.Equal("Rental Record for Fred\n\tThe Cell\t9.0\nYou owed 9.0\nYou earned 2 frequent renter points\n", customer.Statement());
        }

        [Fact]
        public void testDualNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", PriceCode.NewRelease), 3));
            customer.AddRental(new Rental(new Movie("The Tigger Movie", PriceCode.NewRelease), 3));
            Assert.Equal("Rental Record for Fred\n\tThe Cell\t9.0\n\tThe Tigger Movie\t9.0\nYou owed 18.0\nYou earned 4 frequent renter points\n", customer.Statement());
        }

        [Fact]
        public void testSingleChildrensStatement()
        {
            customer.AddRental(new Rental(new Movie("The Tigger Movie", PriceCode.Childrens), 3));
            Assert.Equal("Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points\n", customer.Statement());
        }

        [Fact]
        public void testMultipleRegularStatement()
        {
            customer.AddRental(new Rental(new Movie("Plan 9 from Outer Space", PriceCode.Regular), 1));
            customer.AddRental(new Rental(new Movie("8 1/2", PriceCode.Regular), 2));
            customer.AddRental(new Rental(new Movie("Eraserhead", PriceCode.Regular), 3));

            Assert.Equal("Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n", customer.Statement());
        }

    }
}
