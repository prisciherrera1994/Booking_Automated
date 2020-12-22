using KneatTestAutomation.Handler;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace KneatTestAutomation.PageObject
{
    public class HotelPage
    {
        //Selenium Driver
        readonly private IWebDriver Driver;
        readonly private int timeout = 30;
        readonly private int wait = 5;
        readonly private string OverlayClassName = "sr-usp-overlay sr-usp-overlay--wide";

        //Locator
        readonly private By ThreeStarsRating = By.CssSelector("#filter_class > div:nth-child(2) > a:nth-child(1) > label:nth-child(1) > div:nth-child(2) > span:nth-child(1)");
        readonly private By FourStarsRating = By.CssSelector("#filter_class > div:nth-child(2) > a:nth-child(2) > label:nth-child(1) > div:nth-child(2) > span:nth-child(1)");
        readonly private By FiveStarsRating = By.CssSelector("#filter_class > div:nth-child(2) > a:nth-child(3) > label:nth-child(1) > div:nth-child(2) > span:nth-child(1)");
        readonly private By UnRated = By.CssSelector("#filter_class > div:nth-child(2) > a:nth-child(4) > label:nth-child(1) > div:nth-child(2) > span:nth-child(1)");
        readonly private By HotelList = By.Id("hotellist_inner");
        readonly private By HotelListItems = By.ClassName("sr-hotel__name");
        readonly private By MoreFacilities = By.CssSelector("#filter_facilities > div.filteroptions > button.collapsed_partly_link.collapsed_partly_more");
        readonly private By SpaWellnessCenterFilter = By.CssSelector("#filter_facilities > div.filteroptions > a:nth-child(10) > label > div > span.filter_label");
        public HotelPage(IWebDriver driver)
        {
            Driver = driver;
        }

      // Method to apply the three stars rating filter
        public void ApplyFilterThreeStars()
        {
            Driver.FindElement(ThreeStarsRating).Click();
        }

        // Method to apply the four stars rating filter
        public void ApplyFilterFourStars()
        {
            Driver.FindElement(FourStarsRating).Click();
        }

        // Method to apply the five stars rating filter
        public void ApplyFilterFiveStars()
        {
            Driver.FindElement(FiveStarsRating).Click();
        }

        // Method to apply the unrated filter
        public void ApplyFilterUnrated()
        {
            Driver.FindElement(UnRated).Click();
        }

        // Method to apply the Spa and wellness center filter
        public void ApplyFilterSpaWellnessCenter()
        {
            Driver.FindElement(MoreFacilities).Click();
            WaitHandler.ElementIsPresent(Driver, SpaWellnessCenterFilter, new TimeSpan(0, 0, timeout));
            Driver.FindElement(SpaWellnessCenterFilter).Click();

        }

        // Method to check if a Hotel exists in the hotel list
        public bool VerifyHotelExistence(string HotelName)
        {
            //WaitHandler.ImplicitWait(Driver, new TimeSpan(0, 0, 35));
            while (Driver.PageSource.Contains(OverlayClassName))
            {
                Console.WriteLine("Waiting results");
            }

            var hotelList = Driver.FindElement(HotelList)
                .FindElements(HotelListItems).ToList()
                .Select(x => x.Text)
                .Contains(HotelName);


            return hotelList;
        }
    }
}
