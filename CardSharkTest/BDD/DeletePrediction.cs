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
    public class DeletePrediction : TestHelper
    {
        [ClassInitialize]
        public static void DELSetup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void DELTestSetup()
        {
            TestHelper.TestSetup();
        }

        [TestCleanup]
        public void DELCleanThisUp()
        {
            TestHelper.CleanUp();
        }

        [TestMethod]
        public void ScenarioDeleteSinglePick()
        {
            //string org = "UFC";
            //string eve = "UFC 184 (2/28/2015)";
            //string pick = "Rhonda Rousey";
            //int matchID = 23;

            GivenThatTheOrganizationBoxHasntBeenSelected();
            AndTheEventDropdownIsDisabled();
            WhenIClickOnTheOrganizationDropDown();
            ThenIChooseAnOrganization("UFC");
            AndTheEventDropDownIsEnabled();
            WhenIClickOnTheEventDropDown();
            ThenIChooseAnEvent("UFC 184 (2/28/2015)");
            AndIShouldSeeTheEventCard();
            WhenIChooseAMatchWinner("Not Sure");
            AndIClickTheSaveButton();
            ThenMyPredictionShouldBeRemoved(23);
        }

        [ClassCleanup]
        public static void DELClassCleanThisUp()
        {
            TestHelper.CleanUp();
        }
    }
}
