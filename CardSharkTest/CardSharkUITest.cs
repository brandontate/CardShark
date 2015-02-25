﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace CardSharkTest
{
    
    [TestClass]
    public class CardSharkUITest : TestHelper
    {

        [ClassInitialize]
        public static void UISetup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void UITestSetup()
        {
            TestHelper.TestSetup();
        }

        [TestCleanup]
        public void UICleanThisUp()
        {
            TestHelper.CleanUp();
        }

        [TestMethod]
        public void TestZeroState()
        {
            ComboBox organizationcombo = window.Get<ComboBox>("OrganizationComboBox");
            ComboBox eventcombo = window.Get<ComboBox>("EventComboBox");
           
            Assert.IsTrue(organizationcombo.Enabled);
            Assert.IsFalse(eventcombo.Enabled);
        }

        [TestMethod]
        public void TestZeroStateComboBoxItems()
        {
            ComboBox organizationcombo = window.Get<ComboBox>("OrganizationComboBox");
            ComboBox eventcombo = window.Get<ComboBox>("EventComboBox");

            Assert.AreEqual(organizationcombo.Items[0].Text, "UFC");
            Assert.AreEqual(organizationcombo.Items[1].Text, "WWE");
        }
    }
}
