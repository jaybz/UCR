﻿using HidWizards.UCR.Core.Utilities;
using HidWizards.UCR.Core.Utilities.AxisHelpers;
using NUnit.Framework;

namespace HidWizards.UCR.Tests.UtilityTests.HelperTests
{
    [TestFixture]
    public class SensitivityHelperHelperTests
    {
        [TestCase(Constants.AxisMaxValue, ExpectedResult = Constants.AxisMaxValue, TestName = "SensitivityHelper (Init): Max returns Max")]
        [TestCase(Constants.AxisMinValue, ExpectedResult = Constants.AxisMinValue, TestName = "SensitivityHelper (Init): Min returns Min")]
        [TestCase(0, ExpectedResult = 0, TestName = "SensitivityHelper (Init): 0 returns 0")]
        public long SensitivityHelperInitTests(long inputValue)
        {
            var helper = new SensitivityHelper();
            return helper.ApplyRangeSensitivity(inputValue);
        }

        [TestCase(Constants.AxisMaxValue, 50, ExpectedResult = Constants.AxisMaxValue, TestName = "SensitivityHelper (50): Max returns Max")]
        [TestCase(Constants.AxisMinValue, 50, ExpectedResult = Constants.AxisMinValue, TestName = "SensitivityHelper (50): Min returns Min")]
        [TestCase(Constants.AxisMaxValue, 20, ExpectedResult = Constants.AxisMaxValue, TestName = "SensitivityHelper (20): Max returns Max")]
        [TestCase(Constants.AxisMinValue, 20, ExpectedResult = Constants.AxisMinValue, TestName = "SensitivityHelper (20): Min returns Min")]
        public long SensitivityHelperValueTests(long inputValue, int percentage)
        {
            var helper = new SensitivityHelper {Percentage = percentage};
            return helper.ApplyRangeSensitivity(inputValue);
        }
    }
}
