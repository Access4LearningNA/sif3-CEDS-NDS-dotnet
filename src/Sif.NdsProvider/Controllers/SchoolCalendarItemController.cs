using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;
using Sif.Framework.Providers;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/SchoolCalendarItems")]
    public class SchoolCalendarItemController : BasicProvider<SchoolCalendarItem>
    {
        #region Constructor
        public SchoolCalendarItemController()
            : base(new SchoolCalendarItemService())
        {
        }
        #endregion

        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("SchoolCalendarItem")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]SchoolCalendarItem obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
