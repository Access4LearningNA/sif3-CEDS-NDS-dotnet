#region Namespace
using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;
#endregion

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/StudentSchoolAssociations")]
    public class StudentSchoolAssociationController : BasicProvider<StudentProgramAssociation>
    {
        #region Constructor
        public StudentSchoolAssociationController()
            : base(new StudentSchoolAsociationService())
        {
        }
        #endregion

        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("StudentSchoolAssociation")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]StudentProgramAssociation obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
