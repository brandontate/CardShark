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
    public class ChangePrediction : TestHelper
    {
        [ClassInitialize]
        public static void CPSetup(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void CPTestSetup()
        {
            TestHelper.TestSetup();
        }

        [TestCleanup]
        public void CPCleanThisUp()
        {
            TestHelper.CleanUp();
        }

        [TestMethod]
        public void ScenarioChangeSinglePick()
        {
            string org = "UFC";
            string eve = "UFC 184 (2/28/2015)";
            string currentPick = "Catt Zigano";
            int matchID = 23;
            string previousPick = CardShark.Repository.GuessRepository.guessRepo.RetrieveSavedGuess(matchID);
            
            GivenThatTheOrganizationBoxHasntBeenSelected();
            AndTheEventDropdownIsDisabled();
            WhenIClickOnTheOrganizationDropDown();
            ThenIChooseAnOrganization(org);
            AndTheEventDropDownIsEnabled();
            WhenIClickOnTheEventDropDown();
            ThenIChooseAnEvent(eve);
            AndIShouldSeeTheEventCard();
            WhenIChooseAMatchWinner(currentPick);
            AndIClickTheSaveButton();
            ThenMyPredictionShouldBeChange(previousPick, currentPick);
        }

        [ClassCleanup]
        public static void CPClassCleanThisUp()
        {
            TestHelper.CleanUp();
        }

    }
}
