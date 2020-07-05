using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.Testing
{
    [TestClass]
    public class SeleniumSamples
    {
        [TestMethod]
        public void WebDriverSample()
        {
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new FirefoxDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new InternetExplorerDriver();
            Thread.Sleep(1000);
            driver.Dispose();

        }

        [TestMethod]
        public void WebElementSample()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[contains(.,'Students')]")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SelectElementSample_()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");
            var element = driver.FindElement(By.XPath("//select[@id='SelectedDepartment']"));
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySample_Chrome() 
        {
            var driver = new WebDriverFactory(new DriverParams { 
                Driver = "chrome", Binaries = @"C:\tools" }).Get();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[contains(.,'Students')]")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void WebDriverFactorySample_Edge()
        {
            var driver = new WebDriverFactory(new DriverParams
            {
                Driver = "edge",
                Binaries = @"C:\tools"
            }).Get();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[contains(.,'Students')]")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GoToUrlSampleFw() 
        {
            var driver = new WebDriverFactory(new DriverParams
            { Driver = "chrome", Binaries = @"C:\tools" })
                .Get()
                .GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[contains(.,'Students')]")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams
            { Driver = "chrome", Binaries = @"C:\tools" })
                .Get();
            driver
                .GoToUrl("https://gravitymvctestapplication.azurewebsites.net/")
                .GetElement(By.XPath("//a[contains(.,'Students')]"))
                .Click();

            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SelectElementSample() 
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\tools" })
            .Get();
            
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");
            
            driver
                .FindElement(By.XPath("//select[@id='SelectedDepartment']"))
                .AsSelect()
                .SelectByValue("4");
            
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams
            { Driver = "chrome", Binaries = @"C:\tools" })
                .Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            var elements = driver.GetElements(By.XPath("//ul/li"));

            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisibleElementSample() 
        {
            var driver = new WebDriverFactory(new DriverParams
            { Driver = "chrome", Binaries = @"C:\tools" })
            .Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            var element = driver.GetVisibleElement(By.XPath("//a[contains(.,'Students')]"));
            element.Click();

            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisibleElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams
            { Driver = "chrome", Binaries = @"C:\tools" })
            .Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            var elements = driver.GetVisibleElements(By.XPath("//ul/li"));
 
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetEnabledElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams
            { Driver = "chrome", Binaries = @"C:\tools" })
            .Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            var element = driver.GetEnabledElement(By.XPath("//input[@id='SearchString']"));
            element.SendKeys("Hello");

            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void VerticalWindowScrolSample()
        {
            var driver = new WebDriverFactory(new DriverParams
            { Driver = "chrome", Binaries = @"C:\tools" })
            .Get();

            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.Manage().Window.Size = new System.Drawing.Size(100, 350);
            driver.VerticalWindowScrol(1000);

            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ActionsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\tools" })
            .Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.GetVisibleElement(By.XPath("//a[contains(.,'Students')]"))
                .Actions().Click().Build().Perform();

            Thread.Sleep(2000);
            driver.Dispose();
        }

    }
}
