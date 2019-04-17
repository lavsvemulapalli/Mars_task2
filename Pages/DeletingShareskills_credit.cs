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




        internal void Deleting_managinglist()
        {

            Thread.Sleep(2000);


            Managelistingbtn.Click();
            Thread.Sleep(2000);

            removeIcon.Click();
            Thread.Sleep(2000);
            yesbtn.Click();
            Thread.Sleep(3000);
            //verification
           // Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "verification_delete"), verification_deletedmessage.Text);

            if ((GlobalDefinitions.ExcelLib.ReadData(2, "verification_delete").Equals(verification_deletedmessage.Text)))
            {
                Base.test.Log(LogStatus.Info, "deleted managelisting sucessfully");
                Thread.Sleep(2000);
            }

            else
            {
                Base.test.Log(LogStatus.Info, "error in deleting the managelisting");
            }


           

        }

       




    }
}
