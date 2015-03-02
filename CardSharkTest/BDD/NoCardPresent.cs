﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace CardSharkTest.BDD
{
    [TestClass]
    public class NoCardPresent : TestHelper
    {
        [ClassInitialize]
        public static void NCSetup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void NCTestSetup()
        {
            TestHelper.TestSetup();
        }

        [TestCleanup]
        public void NCCleanThisUp()
        {
            TestHelper.CleanUp();
        }

        [TestMethod]
        public void ScenarioCardHasNothing()
        {
            GivenThatTheOrganizationBoxHasntBeenSelected();
            AndTheEventDropdownIsDisabled();
            WhenIClickOnTheOrganizationDropDown();
            ThenIChooseAnOrganization("UFC");
            AndTheEventDropDownIsEnabled();
            WhenIClickOnTheEventDropDown();
            ThenIChooseAnEvent("UFC Test (1/31/2015)");
            AndIDontSeeTheEventCard();
        }

        [ClassCleanup]
        public static void NCClassCleanThisUp()
        {
            TestHelper.CleanUp();
        }
    }
}
