﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidWizards.UCR.Core.Utilities;
using HidWizards.UCR.Core.Utilities.AxisHelpers;
using NUnit.Framework;

namespace HidWizards.UCR.Tests.UtilityTests.HelperTests
{
    [TestFixture]
    public class DeadZoneHelperTests
    {
        [TestCase(Constants.AxisMaxValue, ExpectedResult = Constants.AxisMaxValue, TestName = "DeadZoneHelper (Init): Max returns Max")]
        [TestCase(Constants.AxisMinValue, ExpectedResult = Constants.AxisMinValue, TestName = "DeadZoneHelper (Init): Min returns Min")]
        [TestCase(0, ExpectedResult = 0, TestName = "DeadZoneHelper (Init): 0 returns 0")]
        [TestCase(1, ExpectedResult = 1, TestName = "DeadZoneHelper (Init): 1 returns 1")]
        [TestCase(-1, ExpectedResult = -1, TestName = "DeadZoneHelper (Init): -1 returns -1")]
        public long DeadZoneHelperInitTests(long inputValue)
        {
            var helper = new DeadZoneHelper();
            return helper.ApplyRangeDeadZone(inputValue);
        }

        [TestCase(Constants.AxisMaxValue, 50, ExpectedResult = Constants.AxisMaxValue, TestName = "DeadZoneHelper (50): Max returns Max")]
        [TestCase(Constants.AxisMinValue, 50, ExpectedResult = Constants.AxisMinValue, TestName = "DeadZoneHelper (50): Min returns Min")]
        [TestCase(0, 50, ExpectedResult = 0, TestName = "DeadZoneHelper (50): 0 returns 0")]
        [TestCase(16384, 50, ExpectedResult = 1, TestName = "DeadZoneHelper (50): Positive values above 16383 are outside DZ")]
        [TestCase(-16384, 50, ExpectedResult = -1, TestName = "DeadZoneHelper (50): Negative values below 16383 are outside DZ")]
        [TestCase(16383, 50, ExpectedResult = 0, TestName = "DeadZoneHelper (50): Positive values below 16384 are inside DZ")]
        [TestCase(-16383, 50, ExpectedResult = 0, TestName = "DeadZoneHelper (50): Negative values below 16384 are inside DZ")]
        public long DeadZoneHelperValueTests(long inputValue, int percentage)
        {
            var helper = new DeadZoneHelper { Percentage = percentage };
            return helper.ApplyRangeDeadZone(inputValue);
        }
    }
}
