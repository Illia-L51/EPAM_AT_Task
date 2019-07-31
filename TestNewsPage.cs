using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPAM_AT_Task
{
    [TestClass]
    public class TestNewsPage
    {

        static IWebDriver driver = new ChromeDriver();
        Validators Assert = new Validators(driver);
        MenuElement menu = new MenuElement(driver);
        NewsPage newsPage = new NewsPage(driver);
        SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
       

        [TestMethod]
        public void CheckFirstNews()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            menu.GoToNews();
            Assert.CompareElementText(newsPage.GetFirstNewsTitle(), "Who stood out in Democratic debate?");
            
        }

        [TestMethod]
        public void CheckFiveNews()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com");
            menu.GoToNews();
            List<string> expTitles = new List<string>() {
            "HK protesters hurt in drive-by fireworks attack",
            "Toddler falls six storeys and survives",
            "Canada murder suspects were stopped but let go",
            "Ronald Reagan called Africans at UN 'monkeys'",
            "S Korean doomsday cult leader jailed for six years"};
            Assert.CompareElementsText(newsPage.GetNewsTitles(), expTitles);

        }

        [TestMethod]
        public void CheckNewsSection()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com");
            menu.GoToNews();
            Assert.CompareElementText(newsPage.GetNewsSections(0), "US & Canada");
            string text = newsPage.GetNewsSections(0);
            menu.FindText(newsPage.GetNewsSections(0));
            menu.ClickSearch();
            Assert.CompareElementText(searchResultsPage.GetElementTitle(0), text);
        }

    }

   
}
