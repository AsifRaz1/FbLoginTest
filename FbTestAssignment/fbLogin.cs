using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace FbTestAssignment
{
    class fbLogin
    {

        IWebDriver driver = new ChromeDriver();
        /// <summary>
        /// Facebook login setup
        /// </summary>
        [SetUp]
        public void _fbSetup()
        {
            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(FbResource.TestURL);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                IWebElement userName = driver.FindElement(By.Id("email"));
                userName.SendKeys(FbResource.FbId);
                IWebElement FbPassword = driver.FindElement(By.Id("pass"));
                FbPassword.SendKeys(FbResource.fbPass);
                IWebElement loginbtn = driver.FindElement(By.Id("loginbutton"));
                loginbtn.Click();
                Actions act = new Actions(driver);
                driver.SwitchTo().Alert().Dismiss();
            }
            catch
            {
               // Console.WriteLine("Login failed.");
            }
        }

        /// <summary>
        /// facebook story check 
        /// </summary>
        [Test]
        public void _storyCheck()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='fb_stories_card_root']/div/div/div[1]")));
                IWebElement story = driver.FindElement(By.XPath("//*[@id='fb_stories_card_root']/div/div/div[1]"));
                IWebElement NewsFeed = driver.FindElement(By.CssSelector("span[class*='timestampContent']"));

                Console.WriteLine("story exists=" + story.Displayed);
                Console.WriteLine("Recent Story : " + NewsFeed.Text);
            }
            catch
            {
                Console.WriteLine("No story found.");
            }
        }

        /// <summary>
        ///  facebook birthday check
        /// </summary>
        [Test]
        public void _BirthdayCheck()
        {
            try
            {
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait1.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='pagelet_reminders']/div/div/div/div/a/div/div/span/span/strong")));
                IWebElement birthday = driver.FindElement(By.XPath("//*[@id='pagelet_reminders']/div/div/div/div/a/div/div/span/span/strong"));
                Console.WriteLine("story exists=" + birthday.Displayed);
                if (birthday.Displayed)
                {
                    try
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='pagelet_reminders']/div/div/div/div/a/div/div/span/span[2]")));
                        IWebElement birthcount = driver.FindElement(By.XPath("//*[@id='pagelet_reminders']/div/div/div/div/a/div/div/span/span[2]"));

                        if (birthday.Text.Trim().Contains("other"))
                        {
                            char[] array = birthday.Text.Trim().ToCharArray();
                            int count = int.Parse(array[0].ToString());
                            Console.WriteLine("Birthday count: " + (count + 1));
                        }
                        else
                        {
                            Console.WriteLine("Birthday count: " + 1);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Birthday count: " + 1);
                    }
                }
                else
                {
                    Console.WriteLine("No Birthday section present");
                }
            }
            catch
            {
                Console.WriteLine("No birthday story exist.");
            }
        }

        /// <summary>
        /// facebook message check 
        /// </summary>
        [Test]
        public void _MessageCheck()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='navItem_217974574879787']/a/div")));
                IWebElement messgaebox = driver.FindElement(By.XPath("//*[@id='navItem_217974574879787']/a/div"));
                messgaebox.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                IList<IWebElement> List = driver.FindElements(By.XPath("//*[@id='js_2']/div[1]/div/div[2]/div"));

                for (int i = 0; i < List.Count; i++)
                {
                    if (i > 1)
                    { break; }
                    Console.WriteLine("Text message " + List[i].Text);
                }
            }
            catch
            {
                Console.WriteLine("No message inbox");
            }
        }
    }
}
