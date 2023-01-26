using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWalkthrough
{
    public class SeleniumLab
    {
        //  Given I am on the "Status Code List" page
        //  When I select the "Sort by values" tab
        //  Then the status codes should be sorted in Descending order by code values

        [Test]
        [Category("Happy")]
        public void GivenIAmOnStatusCodeListPage_WhenISelectSortByValuesTab_DescendingCodeValuesListed()
        {
          

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/status_codes");

                // Find the sort by values tab and click on it
                var sortTab = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/a")); 
                sortTab.Click(); 

                bool isSorted = true;
                List<int> statusCodes = new List<int>();

                // Take the status codes from the link and store them in a list

                for (int i = 0; i < statusCodes.Count - 1; i++)
                {
                    if (statusCodes[i] < statusCodes[i + 1])
                    {
                        isSorted = false;
                    }
                }
                Assert.IsTrue(isSorted);

            }
        }
        [Test]
        [Category("Key Presses")]
         // Given I am on the key press page of the website
         // When I input the letter "x"
         // Then I should see a message that says "You entered: X"

        public void GivenIAmOnKeyPressesPage_WhenIInputX_ReturnYouTypedX()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/key_presses");

                // Type X into search bar
                driver.FindElement(By.Id("target")).SendKeys("X");

                // Find the message on the page
                var returnMessage = driver.FindElement(By.Id("result"));

                Assert.That(returnMessage.Text, Is.EqualTo("You entered: X"));

            }
        }
        [Test]
        [Category("Form Authentication")]
        // Given I am on the login page of the website
        // When I enter my valid username and password and submit the form
        // Then I should be taken to a secure page.
        public void GivenIAmOnLoginPage_WhenIEnterAValidUsernameAndValidPassword_TakeMeToSecurePage()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

                var userNameField = driver.FindElement(By.Id("username"));

                userNameField.SendKeys("tomsmith");

                var passwordField = driver.FindElement(By.Id("password"));

                passwordField.SendKeys("SuperSecretPassword!");

                driver.FindElement(By.XPath("//*[@id=\"login\"]/button")).Click();

                Assert.That(driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"));

            }
        }

        [Test]
        [Category("Forgot Password")]

            //Given I am on the forgot password page of the website
            //When I enter my email address and submit the form
            //Then I should receive a "Secure internal service error" message.
        public void GivenIAmOnForgotPassword_WhenIEnterAEmail_TakeMeToSecurePage()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/forgot_password");

                var emailTab = driver.FindElement(By.Id("email"));

                emailTab.SendKeys("maajid@spartaglobal.com");

                driver.FindElement(By.ClassName("radius")).Click();

                var message = driver.FindElement(By.XPath("/html/body/h1")).Text;

                Assert.That(message, Is.EqualTo("Internal Server Error"));
            }
        }

        [Test]
        [Category("Dynamic Loading")]

        //Given I am on the dynamic loading website
        //When I click on "Example 1"
        //And I click on "Start" button
        //Then I should see the "Hello World!" message displayed.
        
        public void GivenIAmOnHomePage_WhenISelectExample1ThenStart_HelloWorld()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading");

                 driver.FindElement(By.XPath("//*[@id=\"content\"]/div/a[1]")).Click();
               
                driver.FindElement(By.XPath("//*[@id=\"start\"]/button")).Click();
                Thread.Sleep(5000);

                var message = driver.FindElement(By.Id("finish")).Text;

                Assert.That(message, Is.EqualTo("Hello World!"));
            }
        }
    }
}
