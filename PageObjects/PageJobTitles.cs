using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace seleniumHW.PageObjects
{
    public class PageJobTitles
    {
        protected WebDriver driver;
        private readonly string title;
        private readonly By jobBy;
        private readonly By deleteJobBy;
        private readonly By addBy = By.XPath("//button[text()=' Add ']");
        private readonly By confirmDelete = By.XPath("//button[text()=' Yes, Delete ']");

        public PageJobTitles(WebDriver driver, string title)
        {
            this.driver = driver;
            this.title = title;
            jobBy = By.XPath("//div[text() = '" + title + "']");
            deleteJobBy = By.XPath("//div[text() = '" + title + "']//ancestor::div[@class='oxd-table-card']//child::i[@class='oxd-icon bi-trash']");
        }
        public void Wait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(addBy));
        }
        public bool IsElementPresent()
        {
            try
            {
                driver.FindElement(jobBy);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void DeleteElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(deleteJobBy).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(confirmDelete));
            driver.FindElement(confirmDelete).Click();
        }

    }
}
