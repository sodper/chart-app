using System.Drawing;
using ChartAppApi.Models;

namespace ChartAppApi.Logic
{
    public class RandomChartData : IChartData
    {
        public Chart GetChart()
        {
            return new Chart
            {
                Colors = new []{ Color.Bisque, Color.Aqua },
                Data = new [] { 142, 133 },
                Labels = new [] { "Jan", "Feb" }
            };
        }
    }
}