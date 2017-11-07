using System;
using System.Drawing;
using ChartAppApi.Models;

namespace ChartAppApi.Logic
{
    public class RandomChartData : IChartData
    {
        private readonly Random _rng;
        private readonly string _labelData = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int MaxNoOfDataPoints = 15;
        private const int MaxDataValue = 3000;

        public RandomChartData()
        {
            _rng = new Random();
        }

        public RandomChartData(int seed)
        {
            _rng = new Random(seed);
        }

        public Chart GetChart()
        {
            var noOfDatapoints = _rng.Next(1, MaxNoOfDataPoints);
            var randomChart = Chart.CreateChart(noOfDatapoints);

            for (var i = 0; i < noOfDatapoints; i++)
            {
                randomChart.Colors[i] = GenerateKnownColor();
                randomChart.Data[i] = _rng.Next(0, MaxDataValue);
                randomChart.Labels[i] = _labelData[_rng.Next(0, _labelData.Length-1)].ToString();
            }

            return randomChart;
        }

        private Color GenerateKnownColor()
        {
            var names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            var randomColorName = names[_rng.Next(names.Length)];
            return Color.FromKnownColor(randomColorName);
        }
    }
}