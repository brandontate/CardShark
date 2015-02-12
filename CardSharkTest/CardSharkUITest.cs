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
    public class CardSharkUITest
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\CardSharkTest\\bin\\Debug\\CardShark");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
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

            Assert.AreEqual(organizationcombo.Items[0].Text, "WWE");
            Assert.AreEqual(organizationcombo.Items[1].Text, "UFC");
        }

        [TestMethod]
        public void TestSelectedComboBoxItem0()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");
            organizationcombo.Select(0);
            Assert.AreEqual(organizationcombo.SelectedItemText, "WWE");
        }

        [TestMethod]
        public void TestSelectedComboBoxItem1()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");
            organizationcombo.Select(1);
            Assert.AreEqual(organizationcombo.SelectedItemText, "UFC");
        }

        [TestMethod]
        public void TestEventComboBoxEnabled()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");
            organizationcombo.Select(1);

            Assert.IsTrue(eventcombo.Enabled);
        }

        [ClassCleanup]
        public static void CleanThisUp()
        {
            window.Close();
            application.Close();
        }
    }
}
