using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;


namespace EPAM_AT_Task
{
    class Validators
    {
        private IWebDriver driver;
        public Validators(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void CompareElementText(string elementText, string expectedText)
        {
            Assert.AreEqual(elementText, expectedText);
        }

        public void CompareElementsText(List<string> elementsText, List<string> expectedText)
        {
            for (int i = 0; i < expectedText.Count-1; i++)
            {
                Assert.AreEqual(elementsText[i], expectedText[i]);
            }
        }
        public void VerifyForDisplayed(IWebElement element)
        {

            Assert.AreEqual(true, element.Displayed);
        }
        
    }
}
