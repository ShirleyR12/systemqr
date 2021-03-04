using System.Data;

namespace FusionChartsSamples
{
    internal class StaticSource
    {
        private DataTable chartData;

        public StaticSource(DataTable chartData)
        {
            this.chartData = chartData;
        }
    }
}