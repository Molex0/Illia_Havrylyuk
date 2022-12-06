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
    public class PageJobAdd
    {
        protected WebDriver driver;

        private readonly By jobTitleBy = By.XPath("//div[@data-v-2fe357a6]//child::input[@data-v-844e87dc ]");
        private readonly By jobDescription = By.XPath("//textarea[@placeholder='Type description here']");
        private readonly By notesBy = By.XPath("//textarea[@placeholder='Add note']");
        private readonly By saveBy = By.XPath("//button[text()=' Save ']");

        public PageJobAdd(WebDriver driver)
        {
            this.driver = driver;
        }

        public PageJobTitles AddJob(string title, string description, string notes)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(saveBy));

            driver.FindElement(jobTitleBy).SendKeys(title);
            driver.FindElement(jobDescription).SendKeys(description);
            driver.FindElement(notesBy).SendKeys(notes);
            driver.FindElement(saveBy).Click();
            return new PageJobTitles(driver, title);
        }
    }
}
