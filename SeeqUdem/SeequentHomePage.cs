using System;

namespace SeeqUdem
{
    internal class SeequentHomePage
    {
        private object driver;

        public SeequentHomePage(object driver)
        {
            this.driver = driver;
        }

        public bool IsVisible { get; internal set; }

        internal void GoTo()
        {
            throw new NotImplementedException();
        }

        internal SequeentSolutionsPage GotoSolutions()
        {
            throw new NotImplementedException();
        }
    }
}