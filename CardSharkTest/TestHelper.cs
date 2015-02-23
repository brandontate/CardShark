﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using CardShark.Model;

namespace CardSharkTest
{
    public class TestHelper
    {
        //private static TestContext test_context;
        protected static Window window;
        private static Application application;
        //private static CardContext context;
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
            //context = _context;
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
 
    }
}
