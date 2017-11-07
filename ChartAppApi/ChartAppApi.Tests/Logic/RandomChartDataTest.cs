using System.Text.RegularExpressions;
using ChartAppApi.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChartAppApi.Tests.Logic
{
    [TestClass]
    public class RandomChartDataTest
    {
        [TestMethod]
        public void GetChart_RandomNumberOfItems()
        {
            var data1 = new RandomChartData(0);
            var noOfDataPoints1 = data1.GetChart().Data.Length;
            var data2 = new RandomChartData(1);
            var noOfDataPoints2 = data2.GetChart().Data.Length;

            Assert.AreNotEqual(noOfDataPoints1, noOfDataPoints2);
        }

        [TestMethod]
        public void GetChart_LabelsAreAlphaNumericChars()
        {
            var data = new RandomChartData(5);
            var chart = data.GetChart();
            var regex = new Regex(@"[A-Za-z0-9]");

            foreach (var label in chart.Labels)
            {
                Assert.IsTrue(regex.IsMatch(label));
            }
        }

        [TestMethod]
        public void GetChart_DataPointsArePositiveIntegersLessThan3000()
        {
            var data = new RandomChartData(7);
            var chart = data.GetChart();

            foreach (var dataPoint in chart.Data)
            {
                Assert.IsTrue(dataPoint > 0);
                Assert.IsTrue(dataPoint < 3000);
            }
        }

        [TestMethod]
        public void GetChart_ColorsAreKnownColors()
        {
            var data = new RandomChartData(9);
            var chart = data.GetChart();

            foreach (var color in chart.Colors)
            {
                Assert.IsTrue(color.IsKnownColor);
            }
        }
    }
}