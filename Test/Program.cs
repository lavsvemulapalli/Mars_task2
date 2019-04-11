using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

            [Test]
            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                //Profile obj = new Profile();
                //obj.EditProfile();

                ShareSkills_Credit obj1 = new ShareSkills_Credit();
                obj1.Skillslisting();
               

                ShareSkills_SkillsExchange obj2 = new ShareSkills_SkillsExchange();
                obj2.Skillslisting_withSkillsExchange();


                DeletingShareskills_credit obj3 = new DeletingShareskills_credit();
                obj3.Deleting_managinglist();

            }
        }
    }
}