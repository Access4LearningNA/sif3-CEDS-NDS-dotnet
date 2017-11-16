#region Namespace
using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

#endregion

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Leas")]
    public class LeaController : BasicProvider<Lea>
    {
        #region Constructor
        public LeaController()
            : base(new LeaService())
        {
        }
        #endregion

        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Lea")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]Lea obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
