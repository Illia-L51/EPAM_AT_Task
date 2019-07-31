using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EPAM_AT_Task
{
    class Helpers
    {
        private IWebDriver driver;

        public Helpers(IWebDriver _driver)
        {
            driver = _driver;
        }

        private static int scrId = 1;

        public string getLoremCharacters(int amount)
        {
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            driver.Manage().Window.Maximize();

            IWebElement bytesRadio = driver.FindElement(By.Id("bytes"));
            IWebElement amountField = driver.FindElement(By.Id("amount"));
            IWebElement generateButton = driver.FindElement(By.Id("generate"));


            bytesRadio.Click();
            amountField.Clear();
            amountField.SendKeys(amount.ToString());
            generateButton.Click();

            return driver.FindElement(By.XPath("//*[@id='lipsum']/p")).Text;
        }

        public void TakeScreenshot()
        {
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(Directory.GetCurrentDirectory() + "Screenshot" + scrId + ".png" , ScreenshotImageFormat.Png);
            scrId++;
        }
    }
}
