using System.Drawing;

namespace ChartAppApi.Models
{
    public class Chart
    {
        public int[] Data { get; set; }
        public string[] Labels { get; set; }
        public Color[] Colors { get; set; }

        public static Chart CreateChart(int dataCount)
        {
            return new Chart
            {
                Data = new int[dataCount],
                Labels = new string[dataCount],
                Colors = new Color[dataCount]
            };
        }
    }
}