using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Programs")]
    public class ProgramController: BasicProvider<Program>
    {
        #region Constructor
        public ProgramController()
            : base(new ProgramService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Program")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]Program obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
