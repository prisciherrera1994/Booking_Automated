using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using KneatTestAutomation.PageObject;
using OpenQA.Selenium.Chrome;

namespace KneatTestAutomation.TestCase
{
    [TestFixture] 
    class SearchTest
    {
        private IWebDriver Driver;
        private BookingPage bookingPage;
        private HotelPage hotelPage;
        private readonly string place = "Limerick";
        private readonly int months = 3;
        private readonly int daysOccupancy = 1;
        private readonly int adult = 2;
        private readonly int children = 0; 
        private readonly int room = 1;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.booking.com/index.en-gb.html");
            Driver.Manage().Window.Maximize();
            bookingPage = new BookingPage(Driver);
            hotelPage = bookingPage.SearchAs(place, months, daysOccupancy, adult, children, room);
        }
        [TearDown]
        public void TearDown(){

            bookingPage = null;
            hotelPage = null;
            Driver.Close();
            Driver.Quit();
        }
        [Test(Author = "Priscila Herrera",Description = "Apply three starts rating filter and check if the hotel name exists in the hotel list")]
        public void ShouldReturnTrueWhenThreeStarsFilterIsApplied(){
            hotelPage.ApplyFilterThreeStars();
            Assert.IsTrue(hotelPage.VerifyHotelExistence("Travelodge Limerick"));
        }

        [Test(Author = "Priscila Herrera", Description = "Apply three starts rating filter and check if the hotel name does not exist in the hotel list")]
        public void ShouldReturnFalseWhenThreeStarsFilterIsApplied(){
            hotelPage.ApplyFilterThreeStars();
            Assert.IsFalse(hotelPage.VerifyHotelExistence("Clayton Hotel Limerick"));
        }

        [Test(Author = "Priscila Herrera",Description = "Apply four starts rating filter and check if the hotel name exists in the hotel list")]
        public void ShouldReturnTrueWhenFourStarsFilterIsApplied(){
            hotelPage.ApplyFilterFourStars();
            Assert.IsTrue(hotelPage.VerifyHotelExistence("Clayton Hotel Limerick"));
        }

        [Test(Author = "Priscila Herrera",Description = "Apply four starts rating filter and check if the hotel name does not exist in the hotel list")]
        public void ShouldReturnFalseWhenFourStarsFilterIsApplied(){
            hotelPage.ApplyFilterFourStars();
            Assert.IsFalse(hotelPage.VerifyHotelExistence("Travelodge Limerick"));
        }

        [Test(Author = "Priscila Herrera",Description = "Apply five starts rating filter and check if the hotel name exists in the hotel list")]
        public void ShouldReturnTrueWhenFiveStarsFilterIsApplied(){
            hotelPage.ApplyFilterFiveStars();
            Assert.IsTrue(hotelPage.VerifyHotelExistence("The Savoy Hotel"));
        }
        [Test(Author = "Priscila Herrera",
             Description = "Apply five starts rating filter and check if the hotel name does not exist in the hotel list")]
        public void ShouldReturnFalseWhenFiveStarsFilterIsApplied(){
            hotelPage.ApplyFilterFiveStars();
            Assert.IsFalse(hotelPage.VerifyHotelExistence("Travelodge Limerick"));
        }
        [Test(Author = "Priscila Herrera",
             Description = "Apply unrated filter and check if the hotel name exists in the hotel list")]
        public void ShouldReturnTrueWhenUnRatedHotelFilterIsApplied(){
            hotelPage.ApplyFilterUnrated();
            Assert.IsTrue(hotelPage.VerifyHotelExistence("Troy Self Catering Village Limerick Ireland"));
        }
        [Test(Author = "Priscila Herrera",
             Description = "Apply unrated filter and check if the hotel name does not exist in the hotel list")]
        public void ShouldReturnFalseWhenUnRatedHotelFilterIsApplied(){
            hotelPage.ApplyFilterUnrated();
            Assert.IsFalse(hotelPage.VerifyHotelExistence("Travelodge Limerick"));
        }
        [Test(Author = "Priscila Herrera",
              Description = "Apply Spa and wellness center filter and check if the hotel name exists in the hotel list")]
        public void ShouldReturnTrueWhenSpaWellnessCenterFilterIsApplied(){
            hotelPage.ApplyFilterSpaWellnessCenter();
            Assert.IsTrue(hotelPage.VerifyHotelExistence("The Savoy Hotel"));
        }
        [Test(Author = "Priscila Herrera",
             Description = "Apply Spa and wellness center filter and check if the hotel name does not exist in the hotel list")]
        public void ShouldReturnFalseWhenSpaWellnessCenterFilterIsApplied(){
            hotelPage.ApplyFilterSpaWellnessCenter();
            Assert.IsFalse(hotelPage.VerifyHotelExistence("Travelodge Limerick"));
        }
    }
}
