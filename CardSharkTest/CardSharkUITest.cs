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

        [ClassCleanup]
        public static void CleanThisUp()
        {
            window.Close();
            application.Close();
        }
    }
}
