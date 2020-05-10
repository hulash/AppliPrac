using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace SeeqUdem
{
    [TestClass]
    [TestCategory("SeequentSite")]
    public class UnitTest1
    {
        private IWebDriver Driver { get; set; }

        [TestMethod]
        public void TestMethod1()
        {
            Driver = GetChromeDriver();
            var seequentHomePage = new SeequentHomePage(Driver);
            seequentHomePage.GoTo();
            Assert.IsTrue(seequentHomePage.IsVisible);

            var seequentSolutionsPage = seequentHomePage.GotoSolutions();
            Assert.IsTrue(seequentSolutionsPage.IsVisible);
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }
    }
}
