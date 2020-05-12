using OpenQA.Selenium;
using System;

namespace SeeqUdem
{
    internal class SeequentHomePage
    {
        private IWebDriver Driver { get; set; }

        public SeequentHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool IsVisible => PageTitle.Displayed;
        public IWebElement PageTitle => Driver.FindElement(By.XPath(".//*[text()='From Complexity to Clarity'] "));
        public IWebElement SolutionsButton => Driver.FindElement(By.XPath(".//*[text()='Our Solutions'] "));

        
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://www.seequent.com");
        }

        internal SeequentSolutionsPage GotoSolutions()
        {
            SolutionsButton.Click();
            return new SeequentSolutionsPage(Driver);
        }
    }
}