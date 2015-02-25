﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WPFUIItems;
using System.Diagnostics;

namespace CardSharkTest
{
    public class TestHelper
    {
        private static TestContext _context;
        protected static Window window;
        private static Application application;
        private static String applicationPath;

        

        public static void SetupClass(TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            applicationPath = Path.Combine(applicationDir, "..\\..\\..\\CardSharkTest\\bin\\Debug\\CardShark");
        }


        public static void TestSetup()
        {
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
        }

        public static void CleanUp()
        {
            window.Close();
            application.Close();
        }

        public static void ZeroState()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");

            Assert.IsTrue(organizationcombo.Enabled);
            Assert.IsFalse(eventcombo.Enabled);
        }

        public static void ZeroStateComboBox()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");

            Assert.AreEqual(organizationcombo.Items[0].Text, "UFC");
            Assert.AreEqual(organizationcombo.Items[1].Text, "WWE");
        }


        public void ThenMyPredictionShouldSave()
        {
            throw new NotImplementedException();
        }

        public void AndIClickTheSaveButton()
        {
            throw new NotImplementedException();
        }

        public void WhenIChooseAMatchWinner()
        {
            throw new NotImplementedException();
        }

        public void AndIShouldSeeTheEventCard()
        {
            var EventCard = window.Get<Label>("vs");
            Assert.AreNotEqual(typeof(AutomationException), EventCard);
        }

        public void ThenIChooseAnEvent(string ItemChosen)
        {
            var EventDropDown = window.Get<ComboBox>("EventComboBox").Items;
            foreach (var item in EventDropDown)
            {
                if (item.Text == ItemChosen)
                {
                    item.Select();
                }
            }
        }

        public void WhenIClickOnTheEventDropDown()
        {
            ComboBox OrgDropDown = window.Get<ComboBox>("EventComboBox");
            OrgDropDown.Click();
        }

        public void AndTheEventDropDownIsEnabled()
        {
            ComboBox eventcombo = window.Get<ComboBox>("EventComboBox");

            Assert.IsTrue(eventcombo.Enabled);
        }

        public void ThenIChooseAnOrganization(string ItemChosen)
        {
            var OrgDropDown = window.Get<ComboBox>("OrganizationComboBox").Items;
            foreach (var item in OrgDropDown)
            {
                if (item.Text == ItemChosen)
                {
                    item.Select();
                }
            }
        }

        public void WhenIClickOnTheOrganizationDropDown()
        {
            ComboBox OrgDropDown = window.Get<ComboBox>("OrganizationComboBox");
            OrgDropDown.Click();
        }

        public void AndTheEventDropdownIsDisabled()
        {
            ComboBox eventcombo = window.Get<ComboBox>("EventComboBox");

            Assert.IsFalse(eventcombo.Enabled);
        }

        public void GivenThatTheOrganizationBoxHasntBeenSelected()
        {
            TestHelper.ZeroState();
            TestHelper.ZeroStateComboBox();
        }
 
    }
}
