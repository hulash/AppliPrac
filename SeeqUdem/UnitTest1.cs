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
        internal SeequentHomePage SeequentHomePage { get; private set; }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        [TestInitialize]
        public void SetupForEveryTestMethod()
        {
            Driver = GetChromeDriver();
            SeequentHomePage = new SeequentHomePage(Driver);
        }

        [TestMethod]
        [Description ("Check the solutions page link from home page")]
        public void TestMethod1()
        {

            SeequentHomePage.GoTo();
            var seequentSolutionsPage = SeequentHomePage.GotoSolutions();
            AssertPageVisible(seequentSolutionsPage);

        }

        [TestMethod]
        public void TestMethod2()
        {
            
            SeequentHomePage.GoTo();
            var seequentSolutionsPage = SeequentHomePage.GotoSolutions();
            AssertPageVisible(seequentSolutionsPage);
        }

        [TestCleanup]
        public void TearDownForEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        private static void AssertPageVisible(SeequentSolutionsPage seequentSolutionsPage)
        {
            Assert.IsTrue(seequentSolutionsPage.IsVisible, "Solutions page was not visible");
        }


    }
}
