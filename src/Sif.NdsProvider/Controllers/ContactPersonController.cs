using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using  Sif.NdsProvider.Model;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/ContactPersons")]
    public class ContactPersonController: BasicProvider<ContactPerson>
    {
        #region Constructor
        public ContactPersonController()
            : base(new ContactPersonService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("ContactPerson")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]ContactPerson obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
