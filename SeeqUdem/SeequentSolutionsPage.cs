using OpenQA.Selenium;

namespace SeeqUdem
{
    internal class SeequentSolutionsPage
    { 
         private IWebDriver Driver { get; set; }

    public SeequentSolutionsPage(IWebDriver driver)
    {
        Driver = driver;
    }

    public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains("Solutions - Innovative Geoscience Solutions - Seequent");
            }
            internal set { }
        }

    }
}