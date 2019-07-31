using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EPAM_AT_Task
{
    class HaveYourSayPage
    {
        private IWebDriver driver;
        public HaveYourSayPage(IWebDriver _driver)
        {
            driver = _driver;
        }


        private IWebElement questionButton { get { return driver.FindElement(By.LinkText("Do you have a question for BBC News?")); } }
        private IWebElement questionField { get { return driver.FindElement(By.ClassName("text-input--long")); } }
        private IWebElement nameField { get { return driver.FindElement(By.XPath("//input[@placeholder='Name']")); } }
        private IWebElement emailField { get { return driver.FindElement(By.XPath("//input[@placeholder='Email address']")); } }
        private IWebElement ageField { get { return driver.FindElement(By.XPath("//input[@placeholder='Age']")); } }
        private IWebElement postcodeField { get { return driver.FindElement(By.XPath("//input[@placeholder='Postcode']")); } }
        private IWebElement newsCheck { get { return driver.FindElement(By.XPath("//input[@type='checkbox']")); } }
        private IWebElement submitButton { get { return driver.FindElement(By.XPath("//button[@class='button']")); } }
        public List<IWebElement> errorLabels { get { return driver.FindElements(By.ClassName("input-error-message")).ToList(); } }


        public void ClickQuestion()
        {
            questionButton.Click();
        }

        public void EnterQuestion (string text)
        {
            questionField.SendKeys(text);
        }
        public void EnterName(string text)
        {
            nameField.SendKeys(text);
        }
        public void EnterEmail(string text)
        {
            emailField.SendKeys(text);
        }
        public void EnterAge(string text)
        {
            ageField.SendKeys(text);
        }
        public void EnterPostcode(string text)
        {
            postcodeField.SendKeys(text);
        }

        public void SubscribeNews()
        {
            newsCheck.Click();
        }

        public void ClickSubmit()
        {
            submitButton.Click();
        }

        public void FillQuestionForm(string text)
        {
            EnterQuestion(text);
            EnterName("Name");
            EnterEmail("Email@mail.com");
            EnterAge("12");
            EnterPostcode("5555");
            SubscribeNews();
        }
    }
}
