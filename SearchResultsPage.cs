using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace EPAM_AT_Task
{
    class SearchResultsPage
    {
        private IWebDriver driver;

        public SearchResultsPage(IWebDriver _driver)
        {
            driver = _driver;
        }


        private List<IWebElement> elementTitles { get { return driver.FindElements(By.XPath("//h1[@itemprop ='headline']")).ToList(); } }

        public string GetElementTitle(int id)
        {
            return elementTitles[id].Text;
        }
    }
}
