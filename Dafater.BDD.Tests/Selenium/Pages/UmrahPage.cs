

using Musala.BDD.Tests.Pages;
using Musala.BDD.Tests.Selenium.Locators;
using Driver;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Faker;
using System.Threading;

namespace Umrah.BDD.Tests.Selenium.Pages
{   
    public class UmrahPage : PageBase
    {
        public UmrahPage(CustomWebDriver driver) : base(driver)
        {
        }



        public void GivenTheUserEnterallCredentials()
        {
            driver.WaitUntilElementIsVisible(UmrahLocator.umrahUserName, 20);
            driver.SendKeysWithClick(UmrahLocator.umrahUserName, "QAUSR01");
            driver.SendKeysWithClick(UmrahLocator.umrahPass, "123");
            driver.SendKeysWithClick(UmrahLocator.umrahCaptcha, "1");
            driver.ClickOn(UmrahLocator.umrahSignInbtn);


            driver.SendKeysWithClick(UmrahLocator.umrahOtac, "1234");
            driver.ClickOn(UmrahLocator.umrahSend);

        }


        public void WhenUserChangeLanguageToArabic()
        {
            driver.WaitUntilElementIsVisible(UmrahLocator.umrahChangeLanguage, 3);
            driver.ClickOn(UmrahLocator.umrahChangeLanguage);

        }
        public void WhenUserChangeLanguageToArabic2()
        {

            for (int i = 0; i < 500 ; i++)
            {

                driver.WaitUntilElementIsVisible(UmrahLocator.umrahDashboard, 3);

                driver.Pause(3);
                driver.ClickOn(UmrahLocator.umrahAgentsContractsAndWarranties);

                driver.Pause(3);

                driver.ClickOn(UmrahLocator.umrahDashboard);
            }

        }

        public void AssertLanguageIsChanged()
        {
            driver.WaitUntilElementIsVisible(UmrahLocator.umrahChangeLanguage, 200);
            var str = driver.GetText(UmrahLocator.umrahChangeLanguageAssertion);
            Assert.That(str, Does.Contain("لوحة المؤشرات الرئيسية"));

        }



        public void GivenTheUserClickonContactUs()
        {

            driver.ForceClickOn(MusalaLocator.musalaContactUs);
        }

        public void GivenUserEntersCorrectDataButInvalidEmail()
        {

            driver.SendKeysWithClick(MusalaLocator.musalaContactUsName, "name test");
            driver.SendKeysWithClick(MusalaLocator.musalaContactUsEmail, "test@test");
            driver.SendKeysWithClick(MusalaLocator.musalaContactUsMobileNumber, "Mobile test");
            driver.SendKeysWithClick(MusalaLocator.musalaContactUsSubject, "Subject test");
            driver.SendKeysWithClick(MusalaLocator.musalaContactUsMessage, "Message test");
        }

        public void AssertOnEmailValidationMessage()
        {
          var emailErrormessage = driver.GetText(MusalaLocator.musalaContactUsEmailMessage);
            Assert.AreEqual(emailErrormessage, "The e-mail address entered is invalid.");
        }


    }
}
