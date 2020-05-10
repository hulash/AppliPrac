using Applitools;
using Applitools.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace seequentApplitools
{
    [TestFixture(1000)]
    [TestFixture(600)]
    public class seequentTests
    {
        public IWebDriver Driver { get; set; }
        public Eyes Eyes { get; set; }
        public Size Resolution720P => new Size(1280, 720);
        public Size Resolution1080P => new Size(1920, 1080);
        public const string AppName = "sample app 1";
        public string TestCaseName => "Test1";
        private int width_;
        public seequentTests(int width)
        {
            width_ = width;
        }
        public void GoToSeequentPage()
        {
            Driver.Navigate().GoToUrl("https://seequent.com");
        }
        public void GoToBlogFromHome()
        {
            Driver.FindElement(By.XPath("//a[@href='/blog/']")).Click();
        }
        [SetUp]
        public void SetUp()
        {
            {
                Driver = new ChromeDriver();
                Driver.Manage().Window.Size = new Size(width_, 600);
                //set an implicit wait for Selenium so that if it doesn't find an element, it will keep trying for specified amount of time
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Eyes = new Eyes
                {
                    ApiKey = "eKABksDs9aLzPxQJ8jxsi4yK5X06Gbpv6l5ZhvjvNms110"
                };
                Eyes.ForceFullPageScreenshot = true;
            }
        }
        //[Test]
        //public void HomepageLoad()
        //{
        //    GoToSeequentPage();
        //    Eyes.Open(Driver, AppName, TestCaseName, Resolution1080P);
        //    Eyes.CheckWindow("HomePageScreenshot");
        //}
        //[Test]
        //public void BlogCheck()
        //{
        //    GoToSeequentPage();
        //    Driver.FindElement(By.LinkText("All Stories")).Click();
        //    Eyes.Open(Driver, AppName, TestCaseName, Resolution1080P);
        //    Eyes.MatchLevel = MatchLevel.Layout;
        //    Eyes.CheckWindow("BlogScreenshot");
        //}
        [Test]
        public void TestResponsiveness()
        {
            // GoToSeequentPage();
            Driver.Url = "https://seequent.com";
            var homePage = new BasePage.HomePage(Driver);
            var blogPage = homePage.GoToBlogPage();
            var solutionsPage = blogPage.GoToSolutionsPage();
        }
        [TearDown]
        public void TearDown() //you can name this method however you want
        {
            //Close your Selenium browser
            Driver.Quit();
            ////Close applitools eyes so that your test run is saved
            //Eyes.Close();
            ////Quit applitools if it is not already closed
            //Eyes.AbortIfNotClosed();
        }
    }
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly Action<string> uiStateChangedHandler_;
        protected readonly By navMenuLocator = By.ClassName("slide -out -widget - area - toggle mobile - icon slide -out -from - right");
        protected readonly By blogLocator = By.LinkText("All Stories");
        protected readonly By solutionsLocator = By.ClassName("menu-item menu-item-type-post_type menu-item-object-page current-menu-item page_item page-item-1049 current_page_item menu-item-has-children sf-with-ul menu-item-1868");
        public BasePage(string pageName, IWebDriver driver, Action<string> uiStateChangedHandler)
        {
            Name = pageName;
            this.driver = driver;
            uiStateChangedHandler_ = uiStateChangedHandler;
        }
        public string Name { get; private set; }
        public BlogPage GoToBlogPage()
        {
            ClickNavButton(blogLocator);
            return new BlogPage(driver, uiStateChangedHandler_);
        }
        public SolutionsPage GoToSolutionsPage()
        {
            ClickNavButton(solutionsLocator);
            return new SolutionsPage(driver, uiStateChangedHandler_);
        }
        protected void ClickNavButton(By locator)
        {
            var navMenu = driver.FindElement(navMenuLocator);
            if (navMenu.Displayed)
            {
                navMenu.Click();
                FireUIStateChanged("Navigation Menu");
            }
            driver.FindElement(locator).Click();
        }
        protected void FireUIStateChanged(string description)
        {
            if (uiStateChangedHandler_ != null)
            {
                uiStateChangedHandler_(Name + " + " + description);
            }
        }
        public class BlogPage : BasePage
        {
            public BlogPage(IWebDriver driver, Action<string> uiStateChangedHandler = null)
                : base("Blog", driver, uiStateChangedHandler)
            {
            }
        }
        public class HomePage : BasePage
        {
            public HomePage(IWebDriver driver, Action<string> uiStateChangedHandler = null)
                : base("Home", driver, uiStateChangedHandler)
            {
            }
        }
        public class SolutionsPage : BasePage
        {
            public SolutionsPage(IWebDriver driver, Action<string> uiStateChangedHandler = null)
                : base("Solutions", driver, uiStateChangedHandler)
            {
            }
        }
    }
}