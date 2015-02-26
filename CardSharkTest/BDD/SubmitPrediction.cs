﻿﻿using System;
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
    public class SubmitPrediction : TestHelper
    {
        [ClassInitialize]
        public static void SPSetup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SPTestSetup()
        {
            TestHelper.TestSetup();
        }

        [TestCleanup]
        public void SPCleanThisUp()
        {
            TestHelper.CleanUp();
        }

        [TestMethod]
        public void ScenarioSubmitApplication()
        {
            GivenThatTheOrganizationBoxHasntBeenSelected();
            AndTheEventDropdownIsDisabled();
            WhenIClickOnTheOrganizationDropDown();
            ThenIChooseAnOrganization("UFC");
            AndTheEventDropDownIsEnabled();
            WhenIClickOnTheEventDropDown();
            ThenIChooseAnEvent("UFC 184 (2/28/2015)");
            AndIShouldSeeTheEventCard();
            WhenIChooseAMatchWinner("Rhonda Rousey");
            AndIClickTheSaveButton();
            ThenMyPredictionShouldSave();
        }
    }
}
