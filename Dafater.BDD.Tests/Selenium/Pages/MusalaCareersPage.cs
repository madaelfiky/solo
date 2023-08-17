

using Musala.BDD.Tests.Pages;
using Musala.BDD.Tests.Selenium.Locators;
using Driver;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Microsoft.Extensions.Primitives;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Musala.BDD.Tests.Selenium.Pages
{
    public class MusalaCareersPage : PageBase
    {
        public MusalaCareersPage(CustomWebDriver driver) : base(driver)
        {
        }



        public void GivenTheUserClickCareersTapFromTheTop()
        {

            driver.ClickOn(MusalaLocator.musalaCareers);

        }
        public void GivenClickCheckOurOpenPositionsButtonAndVerifiesURL()
        {

            driver.ClickOn(MusalaLocator.musalaaCheckOurOpenPositions);
            Assert.AreEqual("https://www.musala.com/careers/join-us/", driver.GetUrl());


        }

        public void GivenFromTheDropdownSelectLocationSelectAnywhere()
        {
            driver.SelectFromDropDownList(MusalaLocator.musalaLocationDDL, "Anywhere");
        }
        public void GivenChooseOpenPositionByNameAndApply()
        {

            driver.ForceClickOn(MusalaLocator.musalaAutomationQAEngineer);
            driver.WaitUntilElementIsVisible(MusalaLocator.musalaApplyButton, 2);
            driver.ForceClickOn(MusalaLocator.musalaApplyButton);

        }
        public void GivenEnterWrongDetails()
        {

            driver.SendKeysWithClick(MusalaLocator.musalaContactUsName, "");
            driver.SendKeysWithClick(MusalaLocator.musalaContactUsEmail, "aa_1");
            driver.SendKeysWithClick(MusalaLocator.musalaContactUsMobileNumber, "aa");

        }

        public void GivenUploadACVDocumentAndClickSendButton()
        {
            driver.UploadFile(MusalaLocator.musalaUploadButton, "Ahmed El-Fiky.pdf");

        }
        public void ThenPrintJobs()
        {

            var elements = driver.FindElements(MusalaLocator.musalaJobs);

            System.Console.WriteLine("Anywhere Jobs:");
            foreach (IWebElement e in elements)
            {
                System.Console.WriteLine(e.Text);
            }

        }
    }
}
