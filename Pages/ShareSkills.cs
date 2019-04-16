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
        [FindsBy(How = How.XPath, Using = "//label[text()='Hourly basis service']//following::input[1]")] public IWebElement servicetype;
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='1']")] public IWebElement locationType;
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")] public IWebElement startdate;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")] public IWebElement enddate;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[4]")] public IWebElement avilabiltycheckbox;

        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[5]")] public IWebElement avilabiltystarttime;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[6]")] public IWebElement avilabiltyendtime;

        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[7]")] public IWebElement avilabiltycheckboxtue;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[8]")] public IWebElement avilabiltystarttimeontue;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[9]")] public IWebElement avilabiltyendtimeontue;

        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[10]")] public IWebElement avilabiltycheckboxonwed;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[11]")] public IWebElement avilabiltystarttimeonwed;
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']//following::input[12]")] public IWebElement avilabiltyendtimeonwed;



        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='false']")] public IWebElement skillstrade;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")] public IWebElement credit;
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")] public IWebElement WorkSamples;

        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='false']")] public IWebElement active_Hidden;
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")] public IWebElement savebtn;
        [FindsBy(How = How.CssSelector, Using = ".ns-box-inner")] public IWebElement verification_shareskillsCredit;

        [FindsBy(How = How.XPath, Using = "//a[text()='Manage Listings']")] public IWebElement Managelistingbtn;

        [FindsBy(How = How.XPath, Using = "//td[text()='Test Engineer']")] public IWebElement verfication;


        //[FindsBy(How = How.XPath, Using = "//div[@class='ui checkbox']")] public IWebElement days;

        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType']")] public IWebElement servicety;


        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType']//following::div[1]")] IWebElement s;

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
            skillstitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));
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
                int p=i+1;
                String before_xpath ="//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[";
                String after_xpath = "]/div/label";
                var ser_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + p + after_xpath)).Text;

                Console.WriteLine(ser_name);

                if (ser_name.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")))
                {
                    service.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the ServiceType");
                    break;
                }
            }
            Thread.Sleep(2000);
            //entering location type

            IList<IWebElement> location = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='locationType']"));

            int count1 = location.Count;

            for (int i = 0; i < count1; i++)
            {
                int q = i + 1;
                String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div[1]/div[";
                String after_xpath = "]/div/label";
                var loc_name = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + q + after_xpath)).Text;

                Console.WriteLine(loc_name);

                if (loc_name.Equals(GlobalDefinitions.ExcelLib.ReadData(3, "LocationType")))
                {
                    location.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the locationType");
                    break;
                }
            }
            Thread.Sleep(2000);

            //selecting days

            IList<IWebElement> avilabledays = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='Available']"));
            int count3 = avilabledays.Count;
            for (int i = 0; i < count3; i++)
            {

                int r = i + 2;

                String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[";
                String after_xpath = "]/div[1]/div/label";
                var avildays = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + r + after_xpath)).Text;

                Console.WriteLine(avildays);
            
                if(avildays.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Days")))
                {
                    avilabledays.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the monday");
                    
                }

                if (avildays.Equals(GlobalDefinitions.ExcelLib.ReadData(3, "Days")))
                {
                    avilabledays.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the tuesday");
                    
                }

                if (avildays.Equals(GlobalDefinitions.ExcelLib.ReadData(4, "Days")))
                {
                    avilabledays.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Info, "Select the wednesday");
                    break;
                }


            }
                    
          
         //entering avilable days    and time      

           startdate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            Base.test.Log(LogStatus.Info, "enter the start date");
            Thread.Sleep(2000);

            enddate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            Base.test.Log(LogStatus.Info, "enter the end date");
            Thread.Sleep(2000);
                       
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
            //choosing skillstrade

            IList<IWebElement> trade = GlobalDefinitions.driver.FindElements(By.XPath("//input[@name='skillTrades']"));

            int count4 = service.Count;

            for (int i = 0; i < count4; i++)
            {
                int s = i + 1;
                String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[";
                String after_xpath = "]/div/label";
                var trade_sel = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + s + after_xpath)).Text;

                Console.WriteLine(trade_sel);

                if (trade_sel.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "skillTrade")))
                {
                    trade.ElementAt(i).Click();
                    Thread.Sleep(2000);
                    Base.test.Log(LogStatus.Info, "Select the skillTrade as credit");
                    credit.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
                    Base.test.Log(LogStatus.Info, "credit value entered");
                    
                }


                if (trade_sel.Equals(GlobalDefinitions.ExcelLib.ReadData(3, "skillTrade")))
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

            int count5 = activebtn.Count;

            for (int i = 0; i < count5; i++)
            {
                int t = i + 1;
                String before_xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[";
                String after_xpath = "]/div/label";
                var act_sel = GlobalDefinitions.driver.FindElement(By.XPath(before_xpath + t + after_xpath)).Text;

                Console.WriteLine(act_sel);

                if (act_sel.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Active")))
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
            Assert.AreEqual("Test Engineer", verfication.Text);
            Thread.Sleep(2000);



            Base.test.Log(LogStatus.Info, "Added share skills  with skillstrade as credit successfully");
            Thread.Sleep(2000);









        }











    }
}
