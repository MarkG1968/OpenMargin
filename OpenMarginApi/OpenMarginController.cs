using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MarkG1968.OpenMargin
{
    public class OpenMarginController : ApiController
    {
        public OpenMarginController()
        {
        }

        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, new MarginCallModel{ MarginCall = 1000 });
        }
    }
}
