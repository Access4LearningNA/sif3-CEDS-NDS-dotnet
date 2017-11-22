using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;


namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/StaffPersons")]
    public class StaffPersonController: BasicProvider<StaffPerson>
    {
        #region Constructor
        public StaffPersonController()
            : base(new StaffPersonService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("StaffPerson")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]StaffPerson obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
