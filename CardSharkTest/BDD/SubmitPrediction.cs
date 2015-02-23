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
    public class SubmitPrediction : TestHelper
    {
        [ClassInitialize]
        public static void SetupTests(TestContext _context)
        {
            TestHelper.SetupClass(_context);
        }

        [TestInitialize]
        public void SetupTests()
        {
            TestHelper.TestSetup();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            TestHelper.CleanUp();
        }

        [TestMethod]
        public void ScenarioSubmitApplication()
        {
            GivenThatTheOrganizationBoxHasntBeenSelected();
            AndTheEventDropdownIsDisabled();
            WhenIClickOnTheOrganizationDropDown();
            ThenIChooseAnOrganization(); 
            AndTheEventDropDownIsEnabled();
            WhenIClickOnTheEventDropDown();
            ThenIChooseAnEvent();
            AndIShouldSeeTheEventCard();
            WhenIChooseAMatchWinner();
            AndIClickTheSaveButton();
            ThenMyPredictionShouldSave();
        }

        private void ThenMyPredictionShouldSave()
        {
            throw new NotImplementedException();
        }

        private void AndIClickTheSaveButton()
        {
            throw new NotImplementedException();
        }

        private void WhenIChooseAMatchWinner()
        {
            throw new NotImplementedException();
        }

        private void AndIShouldSeeTheEventCard()
        {
            throw new NotImplementedException();
        }

        private void ThenIChooseAnEvent()
        {
            throw new NotImplementedException();
        }

        private void WhenIClickOnTheEventDropDown()
        {
            throw new NotImplementedException();
        }

        private void AndTheEventDropDownIsEnabled()
        {
            throw new NotImplementedException();
        }

        private void ThenIChooseAnOrganization()
        {
            throw new NotImplementedException();
        }

        private void WhenIClickOnTheOrganizationDropDown()
        {
            throw new NotImplementedException();
        }

        private void AndTheEventDropdownIsDisabled()
        {
            throw new NotImplementedException();
        }

        private void GivenThatTheOrganizationBoxHasntBeenSelected()
        {
            TestHelper.ZeroState();
            TestHelper.ZeroStateComboBox();
        }
    }
}
