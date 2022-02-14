using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using System;

namespace AppiumMyTest
{
    public class Tests
    {
        private AppiumDriver<AndroidElement> _driver;

        [SetUp]
        public void Setup()
        {
            
            var appPath = @"C: \Users\yushe\Downloads\ApiDemos - debug.apk";
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability("platformName", "Android");
            driverOption.AddAdditionalCapability("deviceName", "32085c1f98be51f1");
            driverOption.AddAdditionalCapability("app", appPath);
            driverOption.AddAdditionalCapability("chromedriverExecutable", @"C:\Users\yushe\Downloads\chromedriver_win32\chromedriver.exe");

            _driver = new AndroidDriver<AndroidElement>(new System.Uri("http://localhost:4723/wd/hub"), driverOption);
            var contexts = ((IContextAware)_driver).Contexts;
            string webviewContext = null;
            for (var i = 0; i < contexts.Count; i++)
            {
                Console.WriteLine(contexts[i]);
                if (contexts[i].Contains("WEBVIEW"))
                {
                    webviewContext = contexts[i];
                    break;
                }
            }
            ((IContextAware)_driver).Context = webviewContext;
            _driver.FindElementByXPath("//android.widget.TextView[@content-desc='App']").Click();

            var firstStringMenu = _driver.FindElementByXPath("//android.widget.TextView[@content-desc='Access'ibility']").Text;
            Assert.AreEqual("Action Bar", firstStringMenu);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}