using OpenQA.Selenium;

namespace SeeqUdem
{
    internal class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }


    }
}