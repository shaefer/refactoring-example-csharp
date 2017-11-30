using Xunit;

namespace VideoStore
{
    public class StatementTests
    {

        private readonly Customer _customer;

        public StatementTests()
        {
            _customer = new Customer("Casey");
        }

  
        [Fact]
        public void TestSingleNewReleaseStatement()
        {
            _customer.AddRental(new Rental(new Movie("Thor: Ragnarok", PriceCode.NewRelease), 3));
            Assert.Equal("Rental record for Casey\n\tThor: Ragnarok\t9\nAmount owed is 9\nYou earned 2 frequent renter points.", _customer.Statement());
        }

        [Fact]
        public void TestDualNewReleaseStatement()
        {
            _customer.AddRental(new Rental(new Movie("Thor: Ragnarok", PriceCode.NewRelease), 3));
            _customer.AddRental(new Rental(new Movie("Justice League", PriceCode.NewRelease), 3));
            Assert.Equal("Rental record for Casey\n\tThor: Ragnarok\t9\n\tJustice League\t9\nAmount owed is 18\nYou earned 4 frequent renter points.", _customer.Statement());
        }

        [Fact]
        public void TestSingleChildrensStatement()
        {
            _customer.AddRental(new Rental(new Movie("The Last Unicorn", PriceCode.Childrens), 3));
            Assert.Equal("Rental record for Casey\n\tThe Last Unicorn\t1.5\nAmount owed is 1.5\nYou earned 1 frequent renter points.", _customer.Statement());
        }

        [Fact]
        public void TestMultipleRegularStatement()
        {
            _customer.AddRental(new Rental(new Movie("The Matrix", PriceCode.Regular), 1));
            _customer.AddRental(new Rental(new Movie("6 Days 7 Nights", PriceCode.Regular), 2));
            _customer.AddRental(new Rental(new Movie("The Man Who Knew Too Little", PriceCode.Regular), 3));

            Assert.Equal("Rental record for Casey\n\tThe Matrix\t2\n\t6 Days 7 Nights\t2\n\tThe Man Who Knew Too Little\t3.5\nAmount owed is 7.5\nYou earned 3 frequent renter points.", _customer.Statement());
        }

        [Fact]
        public void TestSingleNewReleaseHtmlStatement()
        {
            _customer.AddRental(new Rental(new Movie("Thor: Ragnarok", PriceCode.NewRelease), 3));
            Assert.Equal("<H1>Rental record for <EM>Casey</EM></H1>\nThor: Ragnarok: 9<BR>\n<P>Amount owed is <EM>9</EM></P>\n<P>You earned <EM>2</EM> frequent renter points.</P>", _customer.HtmlStatement());
        }

        [Fact]
        public void TestDualNewReleaseHtmlStatement()
        {
            _customer.AddRental(new Rental(new Movie("Thor: Ragnarok", PriceCode.NewRelease), 3));
            _customer.AddRental(new Rental(new Movie("Justice League", PriceCode.NewRelease), 3));
            Assert.Equal("<H1>Rental record for <EM>Casey</EM></H1>\nThor: Ragnarok: 9<BR>\nJustice League: 9<BR>\n<P>Amount owed is <EM>18</EM></P>\n<P>You earned <EM>4</EM> frequent renter points.</P>", _customer.HtmlStatement());
        }

        [Fact]
        public void TestSingleChildrensHtmlStatement()
        {
            _customer.AddRental(new Rental(new Movie("The Last Unicorn", PriceCode.Childrens), 3));
            Assert.Equal("<H1>Rental record for <EM>Casey</EM></H1>\nThe Last Unicorn: 1.5<BR>\n<P>Amount owed is <EM>1.5</EM></P>\n<P>You earned <EM>1</EM> frequent renter points.</P>", _customer.HtmlStatement());
        }

        [Fact]
        public void TestMultipleRegularHtmlStatement()
        {
            _customer.AddRental(new Rental(new Movie("The Matrix", PriceCode.Regular), 1));
            _customer.AddRental(new Rental(new Movie("6 Days 7 Nights", PriceCode.Regular), 2));
            _customer.AddRental(new Rental(new Movie("The Man Who Knew Too Little", PriceCode.Regular), 3));

            Assert.Equal("<H1>Rental record for <EM>Casey</EM></H1>\nThe Matrix: 2<BR>\n6 Days 7 Nights: 2<BR>\nThe Man Who Knew Too Little: 3.5<BR>\n<P>Amount owed is <EM>7.5</EM></P>\n<P>You earned <EM>3</EM> frequent renter points.</P>", _customer.HtmlStatement());
        }

    }
}
