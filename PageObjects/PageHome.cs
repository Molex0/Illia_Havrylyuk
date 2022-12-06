using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace seleniumHW.PageObjects
{
    public class PageHome
    {
        protected WebDriver driver;

        private readonly By adminBy = By.XPath("//span[text()='Admin']");

        public PageHome(WebDriver driver)
        {
            this.driver = driver;
        }
        public PageAdmin GoToAdminPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(adminBy));
            driver.FindElement(adminBy).Click();
            return new PageAdmin(driver);
        }
    }
}
