﻿﻿using System;
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
        public static void Setup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }
        
        [TestMethod]
        public void TestZeroState()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");
           
            Assert.IsTrue(organizationcombo.Enabled);
            Assert.IsFalse(eventcombo.Enabled);
        }

        [TestMethod]
        public void TestZeroStateComboBoxItems()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");

            Assert.AreEqual(organizationcombo.Items[0].Text, "UFC");
            Assert.AreEqual(organizationcombo.Items[1].Text, "WWE");
        }

        [ClassCleanup]
        public static void CleanThisUp()
        {
            TestHelper.CleanUp();
        }
    }
}
