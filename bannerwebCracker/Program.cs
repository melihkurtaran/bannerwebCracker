using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace bannerwebCracker
{
    class Program
    {
        public static IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new InternetExplorerDriver();

            //Navigate to bannerweb page
            driver.Navigate().GoToUrl("https://bannerweb.sabanciuniv.edu/");
            Console.WriteLine("Opened URL");
        }

        [Test]
        public void Execute()
        {
            //login button in bannerweb main page
            IWebElement loginBtn;

            bool elementPresent = false;
            int numberOfFailures = 0;

            while (!elementPresent) //loop until find the text box
            {
                loginBtn = driver.FindElement(By.ClassName("login"));
                loginBtn.Click();
                driver.Navigate().Forward();
                Thread.Sleep(300);
                try
                {
                    driver.FindElement(By.Name("sidd")); // username box
                    elementPresent = true;
                }
                catch
                {
                    Thread.Sleep(300);
                    elementPresent = false;
                    numberOfFailures++;
                    Console.WriteLine("Element not present");
                    driver.Navigate().Back(); //go back to try again
                }
                Console.WriteLine("Number Of Failures: " + numberOfFailures);
            }
        }

        [TearDown]
        public void CleanUp()
        {
            //driver.Close();
            Console.WriteLine("Closed browser");
        }

    }
}
