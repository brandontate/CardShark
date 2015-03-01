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
            TestHelper.ZeroState();
        }

        [TestMethod]
        public void TestZeroStateComboBoxItems()
        {
            TestHelper.ZeroStateComboBox();
        }
    }
}
