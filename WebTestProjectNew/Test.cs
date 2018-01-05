using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestProjectNew
{
    [TestClass]
    public class Test
    {
        private IWebDriver driver;
        private string baseURL;

        [TestInitialize]
        public void SetUpTest()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            this.driver = new FirefoxDriver(service);
            this.baseURL = "https://www.myfonts.com/";
            this.driver.Navigate().GoToUrl(this.baseURL);
            this.driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestLogin()
        {
            this.driver.FindElement(By.Id("headerLoginUsername")).Click();
            this.driver.SwitchTo().Frame(this.driver.FindElement(By.ClassName("dropdownLoginFrame")));

            this.driver.FindElement(By.XPath("//a[text()='sign up']")).Click();
            this.driver.SwitchTo().DefaultContent();

            this.driver.FindElement(By.Name("newinfo[name]")).Click();
            this.driver.FindElement(By.Name("newinfo[emailAddress]")).Click();
            this.driver.FindElement(By.Name("newinfo[password]")).Click();
            this.driver.FindElement(By.Name("newinfo[confirmPassword]")).Click();

            this.driver.FindElement(By.XPath("//input[@value='Create Account']");

        }

        [TestCleanup]
        public void CleanUp()
        {
            this.driver.Close();
            this.driver.Quit();
        }

        public void IsElementVisible(By element, int timeoutSec = 10)
        {
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeoutSec)).Until(ExpectedConditions.ElementIsVisible(element));
        }
    }
}
