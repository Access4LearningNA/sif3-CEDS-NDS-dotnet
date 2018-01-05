using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;
using Sif.NdsProvider.Validators;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Students")]
    public class StudentController : BasicProvider<Student>
    {
        IHttpActionResult result;
        #region Constructor
        public StudentController()
            : base(new StudentService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Student")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]Student obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {
           
                return base.Post(obj);
        }

        #endregion
    }
}
