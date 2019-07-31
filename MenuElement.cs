using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace EPAM_AT_Task
{
    public class MenuElement
    {
        private IWebDriver driver;
        public MenuElement(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement newsButton { get { return driver.FindElement(By.CssSelector("[href*='https://www.bbc.com/news']")); } }
        private IWebElement searchField { get { return driver.FindElement(By.Id("orb-search-q")); } }
        private IWebElement searchButton { get { return driver.FindElement(By.Id("orb-search-button")); } }


        public void GoToNews()
        {
            newsButton.Click();
        }

        public void FindText(string text)
        {
            searchField.SendKeys(text);
        }

        public void ClickSearch()
        {
            searchButton.Click();
        }

    }
}
