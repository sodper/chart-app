using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ChartAppApi.Logic;
using ChartAppApi.Models;

namespace ChartAppApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChartController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(Chart))]
        public async Task<HttpResponseMessage> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();

            // just read first file if multiple
            var data = await filesReadToProvider.Contents[0].ReadAsStringAsync();

            var service = new ChartService(data);
            var chart = service.GetChart();

            return Request.CreateResponse(HttpStatusCode.OK, chart);
        }

        [HttpGet]
        [ResponseType(typeof(Chart))]
        public HttpResponseMessage GetChart()
        {
            var service = new ChartService();
            var chart = service.GetChart();

            return Request.CreateResponse(HttpStatusCode.OK, chart);
        }
    }
}