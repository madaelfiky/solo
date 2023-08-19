

using Musala.BDD.Tests.Pages;
using Musala.BDD.Tests.Selenium.Locators;
using Driver;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Faker;
using System.Threading;
using BLL.Users;
using BLL.Data;

namespace Solo.BDD.Tests.Selenium.Pages
{   
    public class SoloPage : PageBase
    {
        public SoloPage(CustomWebDriver driver) : base(driver)
        {
        }



        public void GivenTheUserEnterallCredentials()
        {
           
            driver.WaitUntilElementIsVisible(SoloLocator.emailLoginPage, 20);
            driver.SendKeysWithClick(SoloLocator.emailLoginPage, "ashirren@ntgclarity.com");
            driver.SendKeysWithClick(SoloLocator.passwordLoginPage, "P@ssw0rdP@ssw0rd");
            driver.ClickOn(SoloLocator.signInButton);
        }


        public void WhenUserNavigateToFilesPage()
        {
            driver.GoToUrl("https://ps.uci.edu/~franklin/doc/file_upload.html");
            driver.Pause(5);

        }
        public void WhenUserUploadFile()
        {                
            driver.UploadFile(SoloLocator.browseButton, "Ahmed El-Fiky.pdf");
        }
        public void CheckThatTheFileIsUploaded()
        {
            driver.WaitUntilElementIsClickable(SoloLocator.sendFileButton,3);
        }

    }
}
