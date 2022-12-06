using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using seleniumHW.PageObjects;


namespace SeleniumTest
{
    class Sample1
    {
        readonly WebDriver driver = new ChromeDriver();

        [SetUp]

        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test() 
        { 
            PageLogin SignInPage = new PageLogin(driver);
            PageHome HomePage = SignInPage.LoginValidUser("Admin", "admin123");
            PageAdmin PageAdmin = HomePage.GoToAdminPage();
            PageAdmin.GoToJobTitlePage();

            PageJobAdd JobAddPage = PageAdmin.GoToAddJobPage();
            PageJobTitles JobTitles = JobAddPage.AddJob("Test1", "Test1 Description", "Test1 Notes");

            JobTitles.Wait();
            Assert.IsTrue(JobTitles.IsElementPresent());//Check if added job is existing
            JobTitles.DeleteElement();
            JobTitles.Wait();
            Assert.IsFalse(JobTitles.IsElementPresent());//Check if added job is deleted
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }
    }
}