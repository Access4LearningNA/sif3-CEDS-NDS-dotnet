#region Namespace
using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

#endregion

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/DisciplineIncidents")]
    public class DisciplineIncidentController : BasicProvider<DisciplineIncident>
    {
        #region Constructor
        public DisciplineIncidentController()
            : base(new DisciplineIncidentService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("DisciplineIncident")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]DisciplineIncident obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
