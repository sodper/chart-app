using System;
using System.Drawing;
using ChartAppApi.Logic;
using ChartAppApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChartAppApi.Tests.Logic
{
    [TestClass]
    public class ParsedChartDataTest
    {
        [TestMethod]
        public void GetChart_SingleDataPoint()
        {
            var data = new ParsedChartData("#A:RED:5");
            var chart = data.GetChart();
            Assert.AreEqual(5, chart.Data[0]);
            Assert.AreEqual("A", chart.Labels[0]);
            Assert.AreEqual(Color.Red, chart.Colors[0]);
        }

        [TestMethod]
        public void GetChart_MultipleDataPoints()
        {
            var data = new ParsedChartData("#A:RED:5\n#B:BLUE:10\n#C:GREEN:15");
            var chart = data.GetChart();
            CollectionAssert.AreEqual(new[] { 5, 10, 15 }, chart.Data);
            CollectionAssert.AreEqual(new[] { "A", "B", "C" }, chart.Labels);
            CollectionAssert.AreEqual(new[] { Color.Red, Color.Blue, Color.Green }, chart.Colors);
        }

        [TestMethod]
        public void GetChart_TrailingNewline()
        {
            var data = new ParsedChartData("#A:RED:5\n#B:BLUE:10\n");
            var chart = data.GetChart();
            CollectionAssert.AreEqual(new[] { 5, 10 }, chart.Data);
            CollectionAssert.AreEqual(new[] { "A", "B" }, chart.Labels);
            CollectionAssert.AreEqual(new[] { Color.Red, Color.Blue }, chart.Colors);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetChart_NoData_ThrowsException()
        {
            // Should throw exception
            var data = new ParsedChartData("");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFileFormatException))]
        public void GetChart_InvalidData_ThrowsException()
        {
            var data = new ParsedChartData("#A:RED:5\nDKR(#2/)\n#B:BLUE:10\n");

            // Should throw exception
            var chart = data.GetChart();
        }
    }
}