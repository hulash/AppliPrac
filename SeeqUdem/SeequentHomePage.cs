using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace SeeqUdem
{
    internal class SeequentHomePage : BasePage

    {
        public SeequentHomePage(IWebDriver driver) : base(driver){}
        private string PageTitle => "Seequent: Solutions for the mining, civil, environmental & energy industries";
        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }
        public IWebElement SolutionsButton => Driver.FindElement(By.XPath(".//*[text()='Our Solutions'] "));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://www.seequent.com");
            Assert.IsTrue(IsVisible,
               $"Seequent homepage was not visible. Expected=>{PageTitle}." + 
               $"Actual=>{Driver.Title}");
        }

        internal SeequentSolutionsPage GotoSolutions()
        {
            SolutionsButton.Click();
            return new SeequentSolutionsPage(Driver);
        }
    }
}
