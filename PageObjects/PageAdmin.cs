using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace seleniumHW.PageObjects
{
    public class PageAdmin
    {
        protected WebDriver driver;

        //Go to job tab
        private readonly By jobBy = By.XPath("//span[text()='Job ']");
        //Select job titles
        private readonly By jobTitlesBy = By.XPath("//a[text()='Job Titles']");
        //Click add button
        private readonly By jobAddBy = By.XPath("//button[text()=' Add ']");

        public PageAdmin(WebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToJobTitlePage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(jobBy));

            driver.FindElement(jobBy).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(jobTitlesBy));
            driver.FindElement(jobTitlesBy).Click();
        }

        public PageJobAdd GoToAddJobPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(jobAddBy));
            driver.FindElement(jobAddBy).Click();
            return new PageJobAdd(driver);
        }
    }
}
