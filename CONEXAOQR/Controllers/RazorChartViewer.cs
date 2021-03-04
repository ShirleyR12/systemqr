using System.Web;

namespace CONEXAOQR.Controllers
{
    internal class RazorChartViewer
    {
        private HttpContextBase httpContext;
        private string v;

        public RazorChartViewer(HttpContextBase httpContext, string v)
        {
            this.httpContext = httpContext;
            this.v = v;
        }

        public object Image { get; internal set; }
        public object ImageMap { get; internal set; }
    }
}