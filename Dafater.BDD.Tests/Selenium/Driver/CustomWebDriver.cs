using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace Driver
{
    public class CustomWebDriver
    {
        private readonly IWebDriver _driver;
        private readonly int _numberTries = 3;

        public CustomWebDriver(IWebDriver driver)
        {
            this._driver = driver;
        }
        /// <summary>
        /// Click on function with error handler
        /// </summary>
        /// <param name="element">element to click</param>
        /// <param name="numbTries">number of tires if error has been occured</param>
        private void ClickOn(IWebElement element, int numbTries)
        {
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                if (numbTries > 0)
                {
                    WaitUntilElementIsClickable(element, 30);
                    ClickOn(element, numbTries - 1);
                }
                else
                {
                    throw ex;
                }

            }
        }

        /// <summary>
        /// type in element with error handler
        /// </summary>
        /// <param name="by">the element locatory By</param>
        /// <param name="text">the text to type</param>
        /// <param name="numbTries">number of tries to interact with the element</param>       
        private void SendKeys(By by, string text, int numbTries)
        {
            try
            {
                FindElement(by).SendKeys(text);
            }
            catch (Exception ex)
            {
                if (numbTries > 0)
                {
                    WaitUntilElementIsVisible(by, 10);
                    SendKeys(by, text, numbTries - 1);
                }
                else
                {
                    throw ex;
                }

            }
        }

        public void MoveToElement(By by)
        {
            new Actions(_driver).MoveToElement(FindElement(by)).Perform();
        }

        /// <summary>
        /// type in element with clear and error handler
        /// </summary>
        /// <param name="by">the element locator By</param>
        /// <param name="text">the text to type</param>
        /// <param name="numbTries">number of tries to interact with the element</param>
        private void SendKeysWithClear(By by, string text, int numbTries)
        {
            try
            {
                FindElement(by).Clear();
                FindElement(by).SendKeys(text);
            }
            catch (Exception ex)
            {
                if (numbTries > 0)
                {
                    WaitUntilElementIsVisible(by, 30);
                    SendKeysWithClear(by, text, numbTries - 1);
                }
                else
                {
                    throw ex;
                }

            }
        }

        private IWebElement FindElement(By by, int numbTries)
        {
            try
            {
                return _driver.FindElement(by);
            }
            catch (Exception ex)
            {
                if (numbTries > 0)
                {
                    WaitUntilElementIsVisible(by, 20);
                    return FindElement(by, numbTries - 1);
                }
                else
                {
                    throw ex;
                }

            }

        }

        private ReadOnlyCollection<IWebElement> FindElements(By by, int numbTries)
        {
            try
            {
                return _driver.FindElements(by);
            }
            catch (Exception ex)
            {
                if (numbTries > 0)
                {
                    WaitUntilElementIsClickable(by, 30);
                    return FindElements(by, numbTries - 1);
                }
                else
                {
                    throw ex;
                }

            }
        }
        
        public string GetAttribute(By by, string attribute)
        {
            return FindElement(by).GetAttribute(attribute);
        }

        /// <summary>
        /// quite the browser
        /// </summary>
        public void QuitBrowser()
        {
            _driver.Quit();
        }
        
        /// <summary>
        /// Wait Until Element is visible on page
        /// </summary>
        /// <param name="by">the element By locator</param>
        /// <param name="timeOutInSeconds">timeout if the element is not visible</param>
        public bool WaitUntilElementIsVisible(By by, int timeOutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
                return true;
            }
            catch {
                return false;
            }
        }
        
        /// <summary>
        /// Wait until element is not visible on page
        /// </summary>
        /// <param name="by">element locator</param>
        /// <param name="timeOutInSeconds">time out</param>
        public void WaitUntilElementIsNotVisible(By by, int timeOutInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }
        
        public void WaitUntilElementContainsText(By by, string text, int timeOutInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }

        public void WaitUntilElementNotContainsText(By by, string text, int timeOutInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(by, text));
        }

        public void Pause(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
        
        /// <summary>
        /// Check element visibility
        /// </summary>
        /// <param name="by">element locatory By</param>
        /// <returns>bool of visibilty</returns>
        
        public bool IsVisible(By by)
        {
            try
            {
                WaitUntilElementIsVisible(by, 5);
                return _driver.FindElement(by).Displayed;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Wait until element is clickable 
        /// </summary>
        /// <param name="by">element By locator</param>
        /// <param name="timeOutInSeconds">Timeout in seconds</param>
        public void WaitUntilElementIsClickable(By by, int timeOutInSeconds)
        {
            WaitUntilElementIsVisible(by, timeOutInSeconds);
            WaitUntilElementIsClickable(FindElement(by), timeOutInSeconds);
        }
        
        /// <summary>
        /// Wait until element is clickable 
        /// </summary>
        /// <param name="element">element</param>
        /// <param name="timeOutInSeconds">Timeout in seconds</param>
        public void WaitUntilElementIsClickable(IWebElement element, int timeOutInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver => element);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void ScrollToEndPag()
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

        }

        public void ScrollToElement(By by)
        {
            ScrollToElement(FindElement(by));
        }
        
        public void ScrollToElement(IWebElement element)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();            
        }
        
        public IWebElement FindElement(By by)
        {
            return FindElement(by, _numberTries);

        }
        
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return FindElements(by,_numberTries);
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        public string GetUrl()
        {
            return _driver.Url;
        }

        public void ClickOn(By by)
        {
            ClickOn(FindElement(by), _numberTries);
        }
        
        public void ClickOn(IWebElement element)
        {
            ClickOn(element, _numberTries);
        }
        
        public void ForceClickOn(By by)
        {
            ForceClickOn(FindElement(by));
        }

        public void ForceClickOn(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public void HandleSecondTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);   
        }

        public void CheckImage(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("return arguments[0].complete " + " && typeof arguments[0].naturalWidth != \"undefined\" " + "&& arguments[0].naturalWidth > 0", element);           

        }
        public void CheckImage(By by)
        {
            CheckImage(FindElement(by));
        }



        public void Blur(By by)
        {
            Blur(FindElement(by));            
        }
        
        public void Blur(IWebElement element)
        {           
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].blur();return true;", element);
        }

        public void SendKeys(By by, string text)
        {
            SendKeys(by, text, _numberTries);
        }
        public void SendKeysWithClick(By by, string text)
        {
            ClickOn(by);
            SendKeys(by, text, _numberTries);
        }
        public void SendKeysBackSpace(By by)
        {
            SendKeys(by,Keys.Backspace, _numberTries);
        }
        

        public void SendKeysWithClear(By by, string text)
        {
            SendKeysWithClear(by, text, _numberTries);
        }
        
        public string SelectRandomFromComboBox(By by)
        {
            Random random = new Random();
            var selectElement = new SelectElement(FindElement(by));
            int itemCount = FindElements(by).Count;
            int index = random.Next(0, itemCount);
            selectElement.SelectByIndex(index);
            return FindElements(by)[index].Text;
        }
        

        public string GetText(By by)
        {
            return FindElement(by).Text;
        }
        
        public IWebElement GetActiveElement()
        {
            return _driver.SwitchTo().ActiveElement();
        }
        
        public string SelectRandomFromDropDownList(By by)
        {
            Random random = new Random();
            var options = _driver.FindElements(by);
            int index = random.Next(0, options.Count);
            var selectedOption = options[index].Text;
            ClickOn(options[index]);
            return selectedOption;
        }
        
        public void SelectFromDropDownList(By by, string option)
        {
            var options = _driver.FindElements(by);
            foreach (IWebElement webElement in options)
            {
                if (webElement.Text.Equals(option))
                {
                    ClickOn(webElement);
                    break;
                }
            }
        }

        public void UploadFile(By by,string fileName) {            
            SendKeys(by, 
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Substring(6)
                + "\\Resources\\Data\\" 
                + fileName);
        }
    }
}
