using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class DeletingShareskills_credit
    {
        public DeletingShareskills_credit()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Manage Listings']")] public IWebElement Managelistingbtn;

        [FindsBy(How = How.XPath, Using = "//td[text()='Off']//following::i[3]")] public IWebElement removeIcon;

        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")] public IWebElement yesbtn;
        [FindsBy(How = How.CssSelector, Using = ".ns-box-inner")] public IWebElement verification_deletedmessage;
        [FindsBy(How = How.XPath, Using = "//button[@class='ui button otherPage']//following::button")] public IWebElement nexticon;



        internal void Deleting_managinglist()
        {

            Thread.Sleep(2000);


            Managelistingbtn.Click();
            Thread.Sleep(2000);
            IList<IWebElement> managelisting = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr"));
            int count = managelisting.Count;

            for (int i = 0; i < count; i++)
            {
               int k = i + 1;
                string before_xpath = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[";
                string after_xpath = "]/td[3]";

                var manage_listing_title = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + k + after_xpath)).Text;

                Console.WriteLine(manage_listing_title);

                if (manage_listing_title.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "deletion")))
                {

                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + i + "]/td[8]/i[3]")).Click();
                    Thread.Sleep(2000);

                    yesbtn.Click();
                    break;



                }

                else
                {

                    Thread.Sleep(1000);
                    nexticon.Click();
                    Thread.Sleep(4000);
                    for (int j = 1; j < count; j++)
                    {
                        
                        string before_xpath1 = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[";
                        string after_xpath2 = "]/td[3]";
                        var manage_listing_title_nextpage = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath1 + j + after_xpath2)).Text;
                        Console.WriteLine(manage_listing_title_nextpage);

                        if (manage_listing_title_nextpage.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "deletion")))
                        {

                            GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[8]/i[3]")).Click();
                            Thread.Sleep(6000);
                            yesbtn.Click();

                            Thread.Sleep(3000);
                            break;
                        }

                        


                    }


                    
                }




            }

        }
    }
}

                //verification
                // Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "verification_delete"), verification_deletedmessage.Text);

                //if ((GlobalDefinitions.ExcelLib.ReadData(2, "verification_delete").Equals(verification_deletedmessage.Text)))
                //{
                //    Base.test.Log(LogStatus.Info, "deleted managelisting sucessfully");
                //    Thread.Sleep(2000);
                //}

                //else
                //{
                //    Base.test.Log(LogStatus.Info, "error in deleting the managelisting");
                //}











            
