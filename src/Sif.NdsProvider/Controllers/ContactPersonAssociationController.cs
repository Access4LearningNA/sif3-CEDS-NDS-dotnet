using Sif.Framework.Providers;
using Sif.Framework.WebApi.ModelBinders;
using System.Web.Http;
using Sif.NdsProvider.Services;
using Sif.NdsProvider.Model;

namespace Sif.NdsProvider.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/ContactPersonAssociations")]
    public class ContactPersonAssociationController : BasicProvider<ContactPersonAssociation>
    {
        #region Constructor
        public ContactPersonAssociationController()
            : base(new ContactPersonAssociationService())
        {
        }
        #endregion
        #region POSTMethod
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("ContactPersonAssociation")]
        public override IHttpActionResult Post([Microsoft.AspNetCore.Mvc.FromBody]ContactPersonAssociation obj, [MatrixParameter] string[] zone = null, [MatrixParameter] string[] context = null)
        {

            return base.Post(obj);
        }

        #endregion
    }
}
