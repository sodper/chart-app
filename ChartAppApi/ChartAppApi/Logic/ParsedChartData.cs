using System;
using System.Drawing;
using System.Text.RegularExpressions;
using ChartAppApi.Models;

namespace ChartAppApi.Logic
{
    public class ParsedChartData : IChartData
    {
        private readonly string _data;
        private Chart _chart;

        public ParsedChartData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            _data = data;
        }

        public Chart GetChart()
        {
            var regex = new Regex(@"#([A-Za-z0-9]+):(\w+):(\d+)");

            var lines = _data.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            _chart = Chart.CreateChart(lines.Length);

            for (var i = 0; i < lines.Length; i++)
            {
                var match = regex.Match(lines[i]);
                if (match.Success)
                {
                    try
                    {
                        AddDatapoint(i, match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                    }
                    catch (Exception)
                    {
                        throw new InvalidFileFormatException(line: lines[i], lineNumber: i+1);
                    }
                }
                else
                {
                    throw new InvalidFileFormatException(line: lines[i], lineNumber: i+1);
                }
            }
            return _chart;
        }

        private void AddDatapoint(int index, string label, string color, string value)
        {
            _chart.Data[index] = int.Parse(value);
            _chart.Labels[index] = label;
            _chart.Colors[index] = ColorTranslator.FromHtml(color);
        }
    }
}