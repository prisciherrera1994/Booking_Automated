using KneatTestAutomation.Handler;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace KneatTestAutomation.PageObject
{
    //Class to represent the Booking Page
    public class BookingPage
    {
        readonly private IWebDriver Driver;
        readonly private int timeout = 30;
        //Locators
        readonly private By PlaceInput = By.Id("ss");
        readonly private By FirstElementPlace = By.XPath("//*[@id=\"frm\"]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]");
        readonly private By NextCalendarButton = By.CssSelector("#frm > div.xp__fieldset.js--sb-fieldset.accommodation > div.xp__dates.xp__group > div.xp-calendar > div > div > div.bui-calendar__control.bui-calendar__control--next");
        readonly private By RoomsOccupancy = By.CssSelector(".xp__guests__count");
        readonly private By Adults = By.CssSelector("div.sb-group__field:nth-child(1) > div:nth-child(1) > div:nth-child(2) > span:nth-child(3)");
        readonly private By DecreaseAdultsSelector = By.CssSelector("div.sb-group__field:nth-child(1) > div:nth-child(1) > div:nth-child(2) > button:nth-child(2)");
        readonly private By IncreaseAdultsSelector = By.CssSelector("div.sb-group__field:nth-child(1) > div:nth-child(1) > div:nth-child(2) > button:nth-child(4)");
        readonly private By Children = By.CssSelector("div.sb-group__field:nth-child(2) > div:nth-child(1) > div:nth-child(2) > span:nth-child(3)");
        readonly private By DecreaseChildrenSelector = By.CssSelector("div.sb-group__field:nth-child(2) > div:nth-child(1) > div:nth-child(2) > button:nth-child(2)");
        readonly private By IncreaseChildrenSelector = By.CssSelector("div.sb-group__field:nth-child(2) > div:nth-child(1) > div:nth-child(2) > button:nth-child(4)");
        readonly private By Rooms = By.CssSelector("div.sb-group__field:nth-child(3) > div:nth-child(1) > div:nth-child(2) > span:nth-child(3)");
        readonly private By DecreaseRoomsSelector = By.CssSelector("div.sb-group__field:nth-child(3) > div:nth-child(1) > div:nth-child(2) > button:nth-child(2)");
        readonly private By IncreaseRoomsSelector = By.CssSelector("div.sb-group__field:nth-child(3) > div:nth-child(1) > div:nth-child(2) > button:nth-child(4)");
        readonly private By SearchButton = By.CssSelector("#frm > div.xp__fieldset.js--sb-fieldset.accommodation > div.xp__button > div.sb-searchbox-submit-col.-submit-button > button");
        
        public BookingPage(IWebDriver driver){
            Driver = driver;
        }

        //Method to find the place to search on the page
        public void TypePlace(string place){
            Driver.FindElement(PlaceInput).SendKeys(place);
            WaitHandler.ElementIsPresent(Driver, FirstElementPlace, new TimeSpan(0,0, timeout));
            Driver.FindElement(FirstElementPlace).Click();
        }

        //Method to select the Date from on the page
        public void SelectDateFrom(int months) {
            string dateFrom = DateTime.Now.AddMonths(months).ToString("yyyy-MM-dd");
            while (!Driver.PageSource.Contains(dateFrom))
                {
                    Driver.FindElement(NextCalendarButton).Click();
                }
            Driver.FindElement(By.XPath("//td[contains(@data-date,\"" + dateFrom + "\")]")).Click();
        }

        //Method to select the Date to on the page
        public void SelectDateTo(int months, int days){
            string dateTo = DateTime.Now.AddMonths(months).AddDays(days).ToString("yyyy-MM-dd");
            while (!Driver.PageSource.Contains(dateTo)){
                Driver.FindElement(NextCalendarButton).Click();
            }
            Driver.FindElement(By.XPath("//td[contains(@data-date,\"" + dateTo + "\")]")).Click();
        }
        //Method to click the component with the rooms and occupancy to select on the page
        public void ClickRoomOccupancy(){
            Driver.FindElement(RoomsOccupancy).Click(); 
        }

        //Method to increase or decrease the adults
        public void SelectAdults(int adults){
            while (int.Parse(Driver.FindElement(Adults).Text) != adults){
                if (int.Parse(Driver.FindElement(Adults).Text) < adults){
                    Driver.FindElement(IncreaseAdultsSelector).Click();
                }
                else {
                    Driver.FindElement(DecreaseAdultsSelector).Click();
                }

            }
        }
        //Method to increase or decrease the children to select on the page
        public void SelectChildren(int children)
        {
            while (int.Parse(Driver.FindElement(Children).Text) != children){
                if (int.Parse(Driver.FindElement(Children).Text) < children){
                    Driver.FindElement(IncreaseChildrenSelector).Click();
                }
                else{
                    Driver.FindElement(DecreaseChildrenSelector).Click();
                }

            }
        }

        //Method to increase or decrease the rooms to select on the page
        public void SelectRooms(int rooms){
            while (int.Parse(Driver.FindElement(Rooms).Text) != rooms)
            {
                if (int.Parse(Driver.FindElement(Rooms).Text) < rooms){
                    Driver.FindElement(IncreaseRoomsSelector).Click();
                }
                else{
                    Driver.FindElement(DecreaseRoomsSelector).Click();
                }
            }
        }

        //method to click the search button on the web page 
        public void ClickSearchButton(){
            Driver.FindElement(SearchButton).Click();
        }

        //method to perform the search on the web page
        public HotelPage SearchAs(string place, int months, int daysOccupancy, int adults, int children, int rooms) {
            TypePlace(place);
            SelectDateFrom(months);
            SelectDateTo(months, daysOccupancy);
            ClickRoomOccupancy();
            SelectAdults(adults);
            SelectChildren(children);
            SelectRooms(rooms);
            ClickSearchButton();
            return new HotelPage(Driver);
        }
    }
}
