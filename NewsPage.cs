using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EPAM_AT_Task
{
    class NewsPage
    {
        private IWebDriver driver;
        public NewsPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement firstNewTitle { get { return driver.FindElement(By.XPath("//div[contains(concat(' ',normalize-space(@class),' '),' nw-c-top-stories__primary-item')]//h3")); } }
        private List<IWebElement> newsTitles { get { return driver.FindElements(By.XPath("//div[contains(concat(' ',normalize-space(@class),' '),' nw-c-top-stories__secondary-item ')]//h3")).ToList(); } }
        private List<IWebElement> newsSections { get { return driver.FindElements(By.XPath("//a[contains(concat(' ',normalize-space(@class),' '),' gs-c-section-link ')]")).ToList(); } }
        private IWebElement moreButton { get { return driver.FindElement(By.ClassName("nw-c-nav__wide-morebutton__closed")); } }
        private IWebElement haveYourSayButton { get { return driver.FindElement(By.LinkText("Have Your Say")); } }

        public string GetFirstNewsTitle()
        {
            return firstNewTitle.Text;
        }
        public string GetNewsTitle (int id)
        {
            return newsTitles[id].Text;
        }
        public List <string> GetNewsTitles()
        {
            List<string> Values=new List<string>();
            for (int i = 0; i < newsTitles.Count-1; i++)
            {
                Values.Add(newsTitles[i].Text);
            }
            return Values;
        }

        public string GetNewsSections(int id)
        {
            return newsSections[id].Text;
        }

        public void ClickMore()
        {
            moreButton.Click();
        }

        public void ClickHaveYourSay()
        {
            haveYourSayButton.Click();
        }

    }
}
