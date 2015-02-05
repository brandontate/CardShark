﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.BDDfy;

namespace CardSharkTest
{
    /// <summary>
    /// Summary description for StoryTest
    /// </summary>
    [TestClass]
    public class StoryTest
    {
        private static Window window;
        private static Application application;
        private static ComboBox combobox;

        [ClassInitialize]
        public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context)
        {
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\CardSharkTest\\bin\\Debug\\CardShark");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);
        }

        [TestMethod]
        public void TestComboBoxItems()
        {
            WPFComboBox organizationcombo = window.Get<WPFComboBox>("OrganizationComboBox");
            WPFComboBox eventcombo = window.Get<WPFComboBox>("EventComboBox");

            Assert.AreEqual(organizationcombo.Items[0].Text, "WWE");
            Assert.AreEqual(organizationcombo.Items[1].Text, "UFC");
        }

        [ClassCleanup]
        public static void CleanThisUp()
        {
            window.Close();
            application.Close();
        }
    }
}
