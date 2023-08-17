

using Musala.BDD.Tests.Pages;
using Musala.BDD.Tests.Selenium.Locators;
using Driver;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Microsoft.Extensions.Primitives;

namespace Musala.BDD.Tests.Selenium.Pages
{
    public class MusalaCompanyPage : PageBase
    {
        public MusalaCompanyPage(CustomWebDriver driver) : base(driver)
        {
        }



        public void GivenTheUserClickCompanyTapFromTheTopAndVerifiesURL()
        {

            driver.ClickOn(MusalaLocator.musalaCompany);
            Assert.AreEqual("https://www.musala.com/company/", driver.GetUrl());

        }
        public void GivenVerifyThatThereIsLeadershipSection()
        {
            bool elementExist = driver.WaitUntilElementIsVisible(MusalaLocator.musalaLeaderShipSection, 3);
            Assert.AreEqual(true, elementExist);
        }

        public void GivenClickTheFacebookLinkFromTheFooter()
        {
            driver.ForceClickOn(MusalaLocator.musalaFaceBook);
        }
        public void ThenVerifyThatTheCorrectURLAndMusalaSoftProfilePictureAppears()
        {
            driver.Pause(5);
            driver.HandleSecondTab();
            Assert.AreEqual("https://www.facebook.com/MusalaSoft?fref=ts", driver.GetUrl());
            driver.CheckImage(MusalaLocator.musalaProfilePicture);

        }


    }
}
