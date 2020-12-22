using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace KneatTestAutomation.Handler
{
    //Class to handle the explicits waits
    public static class WaitHandler
    {
        //This method wait for any alement for 30 seconds, it returns true if find the element, else it returns false 
        public static IWebElement ElementIsPresent(IWebDriver driver, By locator, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element;   
        }
        public static void ImplicitWait(IWebDriver driver, TimeSpan time)
        {

            while (true)
            {

            }
        }
    }
}
