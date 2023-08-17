

using OpenQA.Selenium;

namespace Musala.BDD.Tests.Selenium.Locators
{
    public class MusalaLocator
    {
        //Kashier
        public static By kashierFullName = By.XPath("//* [@placeholder='Enter full name']");
        public static By kashierStoreName = By.XPath("//* [@placeholder='Enter store name']");
        public static By kashierPhoneNumber = By.XPath("//* [@placeholder='Enter phone number']");
        public static By kashierEmail = By.XPath("//* [@placeholder='Enter email address']");
        public static By kashierPassword = By.XPath("//* [@placeholder='Create password']");
        public static By kashierPassword2 = By.XPath("//* [@placeholder='Re-type password']");
        public static By kashierSignup = By.XPath("//* [@id='register-submit-btn']");
        public static By kashierSignupNextpage = By.XPath("//* [@id='rc-imageselect']");

        //homepage

        public static By musalaLogo = By.XPath("//a [@class='brand' and @title=' Musala Soft']");
        public static By musalaContactUs = By.XPath("//* [@data-alt='Contact us']");
        public static By musalaContactUsName = By.XPath("//* [@name='your-name']");
        public static By musalaContactUsEmail = By.XPath("//* [@name='your-email']");
        public static By musalaContactUsMobileNumber = By.XPath("//* [@name='mobile-number']");
        public static By musalaContactUsSubject = By.XPath("//* [@name='your-subject']");
        public static By musalaContactUsMessage = By.XPath("//* [@name='your-message']");
        public static By musalaContactUsEmailMessage = By.XPath("//* [@data-name='your-email']/span");


        //Company

        public static By musalaCompany = By.XPath("//ul[@class='nav']/li/a [text()='Company']");
        public static By musalaLeaderShipSection = By.XPath("//* [@class='company-members']");
        public static By musalaFaceBook = By.XPath("//* [@class='musala musala-icon-facebook']");
        public static By musalaProfilePicture = By.XPath("//* [@aria-label='Page profile photo']");

        //Careers
        public static By musalaCareers = By.XPath("//ul[@class='nav']/li/a [text()='Careers']");
        public static By musalaaCheckOurOpenPositions  = By.XPath("//* [@data-alt='Check our open positions']");
        public static By musalaLocationDDL = By.XPath("//* [@id='get_location']/option");
        public static By musalaAutomationQAEngineer = By.XPath("//* [text()='Automation QA Engineer']");
        public static By musalaApplyButton = By.XPath("//* [@value='Apply']");
        public static By musalaUploadButton = By.XPath("//* [@name='upload-cv']");
        public static By musalaJobs = By.XPath("//article [contains (@class,('card-jobsHot'))]//h2");

    }
}
