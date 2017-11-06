using ChartAppApi.Models;

namespace ChartAppApi.Logic
{
    public class ChartService
    {
        private readonly IChartData _data;

        public ChartService()
        {
            _data = new RandomChartData();
        }

        public ChartService(string requestData)
        {
            _data = new ParsedChartData(requestData);
        }

        public Chart GetChart()
        {
            return _data.GetChart();
        }
    }
}