﻿using MarsFramework.Global;
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
    class ShareSkills_Credit
    {
        public ShareSkills_Credit()
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
        [FindsBy(How = How.XPath, Using = "//label[text()='Hourly basis service']//preceding::input[1]")] public IWebElement servicetype;
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0']")] public IWebElement locationType;
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

        //dropdown method for category selecting
        public void category(string value)
        {
            new SelectElement(Skillscategory).SelectByText(value);
        }

        //dropdown method for subcategory selecting

        public void subcategory(string value)
        {
            new SelectElement(subcat).SelectByText(value);
        }





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
            //entering description
            skillsdescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));
            //
            Thread.Sleep(3000);

            //selecting category
            category("Programming & Tech");
            Thread.Sleep(2000);
            //selecting subcategory

            subcategory("QA");
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
            // entering service type
            servicetype.Click();
            Thread.Sleep(2000);
            //entering location type
            locationType.Click();

            //entering avilable days    and time      

            startdate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            Thread.Sleep(2000);

            enddate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            Thread.Sleep(2000);
            avilabiltycheckbox.Click();
            Thread.Sleep(2000);
            avilabiltystarttime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            Thread.Sleep(2000);
            avilabiltyendtime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));
            Thread.Sleep(2000);
            avilabiltycheckboxtue.Click();
            Thread.Sleep(2000);
            avilabiltystarttimeontue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Starttime"));
            avilabiltyendtimeontue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));
            Thread.Sleep(2000);
            avilabiltycheckboxonwed.Click();
            avilabiltystarttimeonwed.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "Starttime"));
            avilabiltyendtimeonwed.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));
            Thread.Sleep(2000);
            //choosing skillstrade

            skillstrade.Click();
            Thread.Sleep(2000);
            //entering credit amount
            credit.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            Thread.Sleep(2000);
//uploading sample document
            WorkSamples.Click();
            Thread.Sleep(1000);

            AutoItX3 auto = new AutoItX3();
            auto.WinActivate("Open");
            Thread.Sleep(3000);
            auto.Send(@"F:\word.docx");
            Thread.Sleep(3000);
            auto.Send("{Enter}");
            Thread.Sleep(9000);
            
            //choosing Hidden radio button

            active_Hidden.Click();
            Thread.Sleep(2000);
            //clicking save button
            savebtn.Click();
            Thread.Sleep(3000);



            //verification

            Managelistingbtn.Click();
            Thread.Sleep(2000);
            Assert.AreEqual("Test Engineer", verfication.Text);
            Thread.Sleep(2000);



            Base.test.Log(LogStatus.Info, "Added share skills  with skillstrade as credit successfully");
            Thread.Sleep(2000);









        }











        }
}
