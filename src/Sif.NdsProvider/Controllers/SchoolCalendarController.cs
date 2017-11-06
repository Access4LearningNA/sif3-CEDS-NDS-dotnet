using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/SchoolCalendars")]
    public class SchoolCalendarController : BasicProvider<SchoolCalendar>
    {
        #region Constructor
        public SchoolCalendarController()
            : base(new SchoolCalendarService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("SchoolCalendar")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]SchoolCalendar obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
