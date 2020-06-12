using OpenQA.Selenium;

namespace SeeqUdem
{
    internal class SeequentSolutionsPage : BasePage
    {
        public SeequentSolutionsPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible {
            get
            {
                try
                {
                    return Driver.Title.Contains("Solutions - Innovative Geoscience Solutions - Seequent");
                }
                catch (NoSuchElementException)
                {

                    return false;
                }
             
            }
            internal set { }
        }

    }
}