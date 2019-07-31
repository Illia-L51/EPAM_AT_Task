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
    public class TestQuestionPage
    {
        static IWebDriver driver = new ChromeDriver();
        Validators Assert = new Validators(driver);
        Helpers Help = new Helpers(driver);
        MenuElement menu = new MenuElement(driver);
        NewsPage newsPage = new NewsPage(driver);
        HaveYourSayPage haveYourSayPage = new HaveYourSayPage(driver);

        [TestMethod]
        public void VerifyQuestion()
        {
            
            string lorem = Help.getLoremCharacters(140);
            driver.Navigate().GoToUrl("https://www.bbc.com");

            menu.GoToNews();
            newsPage.ClickMore();
            newsPage.ClickHaveYourSay();

            haveYourSayPage.ClickQuestion();
            haveYourSayPage.FillQuestionForm(lorem);

            Help.TakeScreenshot();
            
        }

        [TestMethod]
        public void VerifyLongQuestion()
        {
            
            string lorem = Help.getLoremCharacters(141);
            driver.Navigate().GoToUrl("https://www.bbc.com");

            menu.GoToNews();
            newsPage.ClickMore();
            newsPage.ClickHaveYourSay();

            haveYourSayPage.ClickQuestion();
            haveYourSayPage.FillQuestionForm(lorem);

            Help.TakeScreenshot();
            
        }

        [TestMethod]
        public void QuestionWithEmptyName()
        {
            
            string lorem = Help.getLoremCharacters(141);
            driver.Navigate().GoToUrl("https://www.bbc.com");

            menu.GoToNews();
            newsPage.ClickMore();
            newsPage.ClickHaveYourSay();
            haveYourSayPage.ClickQuestion();
            haveYourSayPage.EnterQuestion(lorem);
            haveYourSayPage.EnterEmail("name@mail.com");
            haveYourSayPage.EnterAge("12");
            haveYourSayPage.EnterPostcode("5555");
            haveYourSayPage.SubscribeNews();
            haveYourSayPage.ClickSubmit();

            Task.Delay(4000).Wait();
            Assert.VerifyForDisplayed(haveYourSayPage.errorLabels[0]);
           
        }

        [TestMethod]
        public void QuestionWithEmptyEmail()
        {
            driver.Manage().Window.Maximize();
            string lorem = Help.getLoremCharacters(141);
            driver.Navigate().GoToUrl("https://www.bbc.com");

            menu.GoToNews();
            newsPage.ClickMore();
            newsPage.ClickHaveYourSay();
            haveYourSayPage.ClickQuestion();
            haveYourSayPage.EnterQuestion(lorem);
            haveYourSayPage.EnterName("name");
            haveYourSayPage.EnterAge("12");
            haveYourSayPage.EnterPostcode("5555");
            haveYourSayPage.SubscribeNews();
            haveYourSayPage.ClickSubmit();

            Task.Delay(3000).Wait();
            Assert.VerifyForDisplayed(haveYourSayPage.errorLabels[0]);
            
        }

        

    }
}
