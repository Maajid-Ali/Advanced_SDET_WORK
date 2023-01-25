using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWalkthrough;

public class Tests
{
    [Test]
    [Category("Happy")]
    public void GivenIAmOnHomepage_WhenIEnterValidEmailAndPassword_ThenIShouldLandOnInventoryPage()
    {
        var options = new ChromeOptions();
        options.AddArgument("headless");

        using (IWebDriver driver = new ChromeDriver(options))

        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://saucedemo.com");

            var userNameField = driver.FindElement(By.Id("user-name"));

            userNameField.SendKeys("standard_user");

            var passwordField = driver.FindElement(By.Id("password"));

            passwordField.SendKeys("secret_sauce");

            driver.FindElement(By.Id("login-button")).Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

        }
    }

    [Test]
    [Category("UnHappy")]
    public void GivenIAmOnHomepage_WhenIEnterInvalidEmail_ThenIShouldStayOnHomepage()
    {
        //setup headless drivr
        var options = new ChromeOptions();
        options.AddArgument("headless");

        using (IWebDriver driver = new ChromeDriver(options))
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var userNameField = driver.FindElement(By.Id("user-name"));

            userNameField.SendKeys("wrong username");

            var passwordField = driver.FindElement(By.Id("password"));

            passwordField.SendKeys("secret_sauce");

            driver.FindElement(By.Id("login-button")).Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }
    }

}