#region Namespace
using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

#endregion

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Schools")]
    public class SchoolController : BasicProvider<School> 
    {

        #region Constructor
        public SchoolController()
            : base(new SchoolService())
        {
        }
        #endregion

        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("School")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]School obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {
           
            return base.Post(obj);
        }

        #endregion

    }
}
