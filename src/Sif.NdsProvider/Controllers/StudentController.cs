﻿using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Students")]
    public class StudentController : BasicProvider<Student>
    {
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
