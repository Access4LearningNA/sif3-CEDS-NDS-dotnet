#region Namespace
using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

#endregion

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Seas")]
    public class SeaController : BasicProvider<Sea>
    {
        #region Constructor
        public SeaController()
            : base(new SeaService())
        {
        }
        #endregion

        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Sea")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]Sea obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
