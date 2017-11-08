#region Namespace
using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;
#endregion

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/StudentProgramAssociations")]
    public class StudentProgramAssociationController : BasicProvider<StudentProgramAssociations>
    {
        #region Constructor
        public StudentProgramAssociationController()
            : base(new StudentProgramAssociationService())
        {
        }
        #endregion

        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("StudentProgramAssociation")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]StudentProgramAssociations obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
