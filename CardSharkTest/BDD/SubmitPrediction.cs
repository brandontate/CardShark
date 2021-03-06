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
        public void ScenarioSubmitSinglePick()
        {
            string org = "UFC";
            string eve = "UFC 184 (2/28/2015)";
            string pick = "Rhonda Rousey";
            int matchID = 23;

            GivenThatTheOrganizationBoxHasntBeenSelected();
            AndTheEventDropdownIsDisabled();
            WhenIClickOnTheOrganizationDropDown();
            ThenIChooseAnOrganization(org);
            AndTheEventDropDownIsEnabled();
            WhenIClickOnTheEventDropDown();
            ThenIChooseAnEvent(eve);
            AndIShouldSeeTheEventCard();
            WhenIChooseAMatchWinner(pick);
            AndIClickTheSaveButton();
            ThenMyPredictionShouldSave(pick, matchID);
        }

        [ClassCleanup]
        public static void SPClassCleanThisUp()
        {
            TestHelper.CleanUp();
        }
    }
}
