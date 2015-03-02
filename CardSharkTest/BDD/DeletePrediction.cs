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
           // ThenMyPredictionShouldBeRemoved("Not Sure", 23);
        }
    }
}
