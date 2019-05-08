using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;
using RelevantCodes.ExtentReports;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    class ShareSkills
    {
        public ShareSkills()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //click on share skills button       
        [FindsBy(How = How.XPath, Using = "//a[text()='Share Skill']")] public IWebElement shareskillsbtn;

        //next page
        
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")] public IWebElement skillstitle;
        [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")] public IWebElement skillsdescription;
        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")] public IWebElement Skillscategory;
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")] public IWebElement subcat;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add new tag']")] public IWebElement tags;
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")] public IWebElement startdate;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")] public IWebElement enddate;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[5]")] public IWebElement avilabiltystarttime;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[6]")] public IWebElement avilabiltyendtime;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[8]")] public IWebElement avilabiltystarttimeontue;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[9]")] public IWebElement avilabiltyendtimeontue;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[11]")] public IWebElement avilabiltystarttimeonwed;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[12]")] public IWebElement avilabiltyendtimeonwed;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")] public IWebElement credit;
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")] public IWebElement WorkSamples;
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")] public IWebElement savebtn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Manage Listings']")] public IWebElement Managelistingbtn;
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='false']//following::input[1]")] public IWebElement SkillsExchange;



        internal void Skillslisting()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Shareskills");
            Thread.Sleep(1000);
           // click on share skills button
            shareskillsbtn.Click();
            Thread.Sleep(5000);
            //entering title
            skillstitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "Title"));
            Base.test.Log(LogStatus.Info, "enter the title details");
            //entering description
            skillsdescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));
            Base.test.Log(LogStatus.Info, "enter the description  details");
            Thread.Sleep(3000);

            //selecting category

            IList<IWebElement> categeory1 = Skillscategory.FindElements(By.TagName("option"));
            foreach(IWebElement cat in categeory1)
            {
                if(cat.Text== GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
                {
                    cat.Click();
                    Base.test.Log(LogStatus.Info, "Select the category");
                }
            }
           
            //selecting subcategory
            IList<IWebElement> subcategory1 = subcat.FindElements(By.TagName("option"));
            foreach (IWebElement subcat1 in subcategory1)
            {
                if (subcat1.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"))
                {
                    subcat1.Click();
                    Base.test.Log(LogStatus.Info, "Select the subcategory");
                }
            }

            //adding tags
            tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Thread.Sleep(2000);
            tags.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Thread.Sleep(2000);
            tags.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Tags"));
            Thread.Sleep(2000);
            tags.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "Tags"));
            Thread.Sleep(2000);
            tags.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "enter all the tags");
            // entering service type

            IList<IWebElement> service = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='serviceType']"));

            int count = service.Count;

            for (int i = 0; i < count; i++)
            {
                int j = i + 1;
                
                String before_xpath ="//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[";
                String after_xpath = "]/div/label";
                var serviceType_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + j + after_xpath)).Text;

                Console.WriteLine(serviceType_name);

                if (serviceType_name.Equals(GlobalDefinitions.ExcelLib.ReadData(3, "ServiceType")))
                {
                    service.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the ServiceType");
                    
                    break;
                   
                }
                


            }
            Thread.Sleep(2000);
            //entering location type

            IList<IWebElement> location = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='locationType']"));

            int locationtype_count = location.Count;

            for (int i = 0; i < locationtype_count; i++)
            {
                int j = i + 1;
                String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div[1]/div[";
                String after_xpath = "]/div/label";
                var locationType_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + j + after_xpath)).Text;

                Console.WriteLine(locationType_name);

                if (locationType_name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")))
                {
                    location.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the locationType");
                    break;
                }
            }
            Thread.Sleep(2000);

            //selecting days

            IList<IWebElement> avilabledays = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='Available']"));
            int avilabledays_count = avilabledays.Count;
            for (int i = 0; i < avilabledays_count; i++)
            {

                int j = i + 2;

                String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[";
                String after_xpath = "]/div[1]/div/label";
                var avilabledays_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + j + after_xpath)).Text;

                Console.WriteLine(avilabledays_name);
            
                if(avilabledays_name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Days")))
                {
                    avilabledays.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the monday");
                    
                }

                if (avilabledays_name.Equals(GlobalDefinitions.ExcelLib.ReadData(3, "Days")))
                {
                    avilabledays.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the tuesday");
                    
                }

                if (avilabledays_name.Equals(GlobalDefinitions.ExcelLib.ReadData(4, "Days")))
                {
                    avilabledays.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the wednesday");
                    break;
                }


            }


            //entering avilable days    and time      

            //entering startdate
            Console.WriteLine("Start date:" + GlobalDefinitions.ExcelLib.ReadData(3, "Startdate"));
            var start_date = GlobalDefinitions.ExcelLib.ReadData(3, "Startdate");

            string[] splitDate = start_date.Split(' ');
            int countsplitDate = splitDate.Count();
            Console.WriteLine("count of startdate is : " + countsplitDate);
            Console.WriteLine($"string 1 is : {splitDate[0]} ");
            Console.WriteLine($"string 2 is : {splitDate[1]} ");
            startdate.SendKeys(splitDate[0]);
            Base.test.Log(LogStatus.Info, "enter the start date");
            Thread.Sleep(2000);
            
            
            //entering end date
            var end_date = GlobalDefinitions.ExcelLib.ReadData(3, "EndDate");
            string[] splitDate_enddate = end_date.Split(' ');
            int count_splitDate_enddate = splitDate_enddate.Count();
            Console.WriteLine("count of enddate is : " + count_splitDate_enddate);
            Console.WriteLine($"string 1 is : {splitDate_enddate[0]} ");
            Console.WriteLine($"string 2 is : {splitDate_enddate[1]} ");
            enddate.SendKeys(splitDate_enddate[0]);
            Base.test.Log(LogStatus.Info, "enter the end date");
            Thread.Sleep(2000);

            //entering starttime and end time
            avilabiltystarttime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            Thread.Sleep(2000);
            avilabiltyendtime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));
            Thread.Sleep(2000);

            avilabiltystarttimeontue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Starttime"));
            avilabiltyendtimeontue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));
            Thread.Sleep(2000);

            avilabiltystarttimeonwed.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Starttime"));
            avilabiltyendtimeonwed.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));
            Thread.Sleep(2000);
            Base.test.Log(LogStatus.Info, "enter the start time and end time for all days ");
            

            //selecting skills trade

            IList<IWebElement> trade = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='skillTrades']"));

            int trade_count = trade.Count;

            for (int i = 0; i < trade_count; i++)
            {
                int j = i + 1;
                     String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[";
                String after_xpath = "]/div/label";
                var trade_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + j + after_xpath)).Text;

                Console.WriteLine(trade_name);

                if (trade_name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "skillTrade")))
                {
                    trade.ElementAt(i).Click();
                    Thread.Sleep(2000);
                    Base.test.Log(LogStatus.Info, "Select the skillTrade as credit");
                    credit.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
                    Base.test.Log(LogStatus.Info, "credit value entered");

                }


                if (trade_name.Equals(GlobalDefinitions.ExcelLib.ReadData(3, "skillTrade")))
                {
                    trade.ElementAt(i).Click();
                    Thread.Sleep(2000);
                    Base.test.Log(LogStatus.Info, "Select the skillTrade as skills exchange");
                    SkillsExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillsExchange"));
                    Thread.Sleep(2000);
                    SkillsExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(2000);
                    SkillsExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "SkillsExchange"));
                    Thread.Sleep(2000);
                    SkillsExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(2000);
                    SkillsExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "SkillsExchange"));
                    Thread.Sleep(2000);
                    SkillsExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(2000);
                    SkillsExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(5, "SkillsExchange"));
                    Thread.Sleep(2000);
                    SkillsExchange.SendKeys(Keys.Enter);
                    Thread.Sleep(2000);
                    Base.test.Log(LogStatus.Info, "skills exchanges are entered");
                }



            }


            //uploading sample document
            WorkSamples.Click();
            Thread.Sleep(1000);

            AutoItX3 auto = new AutoItX3();
            auto.WinActivate("Open");
            Thread.Sleep(3000);
            auto.Send(GlobalDefinitions.ExcelLib.ReadData(2, "Sample"));
            Thread.Sleep(3000);
            auto.Send("{Enter}");
            Thread.Sleep(5000);
            Base.test.Log(LogStatus.Info, "upload the sample document");
            //choosing Hidden radio button

            IList<IWebElement> activebtn = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='isActive']"));

            int activebtn_count = activebtn.Count;

            for (int i = 0; i < activebtn_count; i++)
            {
                int j = i + 1;
                String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[";
                String after_xpath = "]/div/label";
                var activebtn_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + j + after_xpath)).Text;

                Console.WriteLine(activebtn_name);

                if (activebtn_name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Active")))
                {
                    activebtn.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the hidden");
                    break;
                }
            }

            Thread.Sleep(2000);
            //clicking save button
            savebtn.Click();

            Base.test.Log(LogStatus.Info, "Select the save option");
            Thread.Sleep(3000);



            // verification

            Managelistingbtn.Click();
            Thread.Sleep(2000);
            
            IList<IWebElement> verify = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr"));

            int verify_count = verify.Count;
            for (int i = 0; i < verify_count; i++)
            {
                int j = i + 1;
                String before_xpath = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[";
                String after_xpath = "]/td[3]";
                var verify_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + j + after_xpath)).Text;

                Console.WriteLine(verify_name);

                if (verify_name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Verification")))
                {

                    Base.test.Log(LogStatus.Info, "Added share skills  with skillstrade as credit successfully");
                    break;
                }
            }







        }











    }
}
