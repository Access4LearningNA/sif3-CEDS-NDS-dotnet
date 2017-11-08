using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Person=Sif.NdsProvider.Model.Person;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Persons")]
    public class PersonController : BasicProvider<Person>
    {
        #region Constructor
        public PersonController()
            : base(new PersonService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Person")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]Person obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
