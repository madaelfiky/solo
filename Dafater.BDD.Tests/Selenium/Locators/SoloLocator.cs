

using OpenQA.Selenium;

namespace Musala.BDD.Tests.Selenium.Locators
{
    public class SoloLocator
    {
        //Login
        public static By emailLoginPage = By.XPath("//* [@name='email']");
        public static By passwordLoginPage = By.XPath("//* [@name='password']");
        public static By signInButton = By.XPath("//*[contains(text(),'Sign In')]");

        //UploadFile
        public static By browseButton = By.XPath("//* [@name='userfile']");
        public static By sendFileButton = By.XPath("//* [@type='submit']");
      
    }
}
